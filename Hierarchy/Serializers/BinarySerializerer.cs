using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hierarchy
{
    class BinarySerializerer : ISerializable
    {
        public void Serialize(Stream stream, object element)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, element);
        }

        public object Deserialize(Stream stream, object element)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            element =formatter.Deserialize(stream);             
            return element;
        }
    }
}
