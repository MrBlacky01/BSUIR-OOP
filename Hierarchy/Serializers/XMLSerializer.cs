using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Hierarchy
{
    public class XMLSerializerer : ISerializable
    {
        public XMLSerializerer()
        {
           
        }

        XmlSerializer serializer;

        public void Serialize(Stream stream, object element)
        {
            serializer = new XmlSerializer(element.GetType());
            serializer.Serialize(stream, element);
        }

        public object Deserialize(Stream stream,object element)
        {
            XmlSerializer serializer = new XmlSerializer(element.GetType());
            element = serializer.Deserialize(stream) ;
            return element ;
        }
    }
}
