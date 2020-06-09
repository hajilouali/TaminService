using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Common.Utilities
{
    public static class Jsonfile
    {

        public static PagesConfig xmltoobject()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PagesConfig));

            using (FileStream fileStream = new FileStream(Path.Combine(AppContext.BaseDirectory, "json.xml"), FileMode.Open))
            {
                var result = (PagesConfig)serializer.Deserialize(fileStream);
                return result;
            }  
        }
        public static void objecttoxml(PagesConfig dto)
        {
            XmlSerializer ser = new XmlSerializer(typeof(PagesConfig));

            using (StreamWriter wr = new StreamWriter(Path.Combine(AppContext.BaseDirectory, "json.xml"), false, Encoding.UTF8))
            {
                ser.Serialize(wr, dto);
            }
        }

    }
}
