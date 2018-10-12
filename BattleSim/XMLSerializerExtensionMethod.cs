using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BattleSim
{
    public static class XMLSerializerExtensionMethod
    {
          private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string Serialize<T>(this T value)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                return string.Empty;
            }
            var xmlserializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);
                return stringWriter.ToString();
            }
        }



        public static T DeserializeXMLFileToObject<T>(this string XmlFilename)
        {
            T returnObject = default(T);
     
            if (string.IsNullOrEmpty(XmlFilename))
            {
                log.Error("String null or empty"); 
                return default(T);
            }

            try
            {
                using (StreamReader xmlStream = new StreamReader(XmlFilename))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    returnObject = (T)serializer.Deserialize(xmlStream);
                }
            }
            catch (Exception ex)
            {

                log.Error(ex.Message + " " + DateTime.Now.ToString());
            }
            return returnObject;
        }
    }
}
