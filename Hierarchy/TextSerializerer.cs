using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hierarchy
{
    class TextSerializerer : ISerializable
    {
        public void Serialize(Stream stream, object element)
        {
            List<Drinks> list = element as List<Drinks>;
            foreach (Drinks el in list)
            {
                //byte[] array = System.Text.Encoding.Default.GetBytes(el.ToText()+"\n");
                // запись массива байтов в файл
                byte[] array = Encoding.UTF8.GetBytes(el.ToText() + "\r\n");
                stream.Write(array, 0, array.Length);
            }
        }

        public void Deserialize(Stream stream)
        {

        }
    }
}
