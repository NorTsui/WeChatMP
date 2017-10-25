using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;

namespace WxMP.Core.Utility
{
    /// <summary>
    /// xml序列化
    /// </summary>
    public class Xmls
    {
        #region base
        /// <summary>
        /// XML序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    XmlSerializer xmlSer = new XmlSerializer(obj.GetType());
                    xmlSer.Serialize(ms, obj);
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                using (MemoryStream sr = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)))
                {
                    return (T)xmlSer.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                return default(T);
            }

        }
        #endregion


        #region wechar

        /// <summary>
        /// ELEMENT值格式化为CDATA
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="element"></param>
        private static void ElementToCdata(object obj, XElement element)
        {
            foreach (var el in element.Elements().ToList())
            {
                if (obj.GetType().GetProperty(el.Name.ToString()) != null)
                {
                    //系统类型
                    if (obj.GetType().GetProperty(el.Name.ToString()).PropertyType.FullName.ToLower().Contains("system."))
                    {
                        if (obj.GetType().GetProperty(el.Name.ToString()).PropertyType.FullName.Contains("List`1"))
                        {
                            dynamic objList = obj.GetType().GetProperty(el.Name.ToString()).GetValue(obj);

                            for (int i = 0; i < objList.Count; i++)
                            {
                                var itemEl = el.Elements().ToList()[i];
                                itemEl.Name = "item";
                                ElementToCdata(objList[i], el.Elements().ToList()[i]);
                            }

                        }
                        else if (obj.GetType().GetProperty(el.Name.ToString()).PropertyType.FullName.Contains("[]"))
                        {
                            dynamic objList = obj.GetType().GetProperty(el.Name.ToString()).GetValue(obj);
                            for (int i = 0; i < objList.Count; i++)
                            {
                                var itemEl = el.Elements().ToList()[i];
                                itemEl.Name = "item";
                                ElementToCdata(objList[i], el.Elements().ToList()[i]);
                            }
                        }
                        else if (obj.GetType().GetProperty(el.Name.ToString()).PropertyType == typeof(string))
                        {
                            el.ReplaceWith(new XElement(el.Name, new XCData(el.Value)));
                        }

                    }
                    else//自定义类型，包括枚举，对象
                    {
                        if (obj.GetType().GetProperty(el.Name.ToString()).PropertyType.IsEnum)
                        {
                            el.ReplaceWith(new XElement(el.Name, new XCData(el.Value)));
                        }
                        else
                        {
                            var objModel = obj.GetType().GetProperty(el.Name.ToString()).GetValue(obj);
                            ElementToCdata(objModel, el);
                        }
                    }
                }
                else
                {
                    if (obj.GetType() == typeof(string))
                        el.ReplaceWith(new XElement(el.Name, new XCData(el.Value)));
                }
            }
        }

        /// <summary>
        /// 序列化微信XML对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeForWeChat(object obj)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    XmlSerializer xmlSer = new XmlSerializer(obj.GetType());
                    xmlSer.Serialize(ms, obj);
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        XDocument doc = XDocument.Parse(sr.ReadToEnd());
                        doc.Root.Name = "xml";
                        doc.Root.RemoveAttributes();
                        ElementToCdata(obj, doc.Root);
                        return doc.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 反序列化微信XML对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeForWeChar<T>(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                doc.Root.Name = typeof(T).Name;

                if (typeof(Model.RevertMsgArticle) == typeof(T))
                {
                    foreach (var item in doc.Root.Element("Articles").Elements("item").ToList())
                    {
                        item.Name = "Articles";
                        doc.Root.Add(item);
                    }
                    doc.Root.Element("Articles").Remove();
                }
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                using (MemoryStream sr = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(doc.ToString())))
                {
                    return (T)xmlSer.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        #endregion
    }
}
