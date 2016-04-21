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
                byte[] array = Encoding.UTF8.GetBytes(el.ToText() + "\r\n");
                stream.Write(array, 0, array.Length);
            }
        }

        public virtual object Deserialize(Stream stream,object element)
        {
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(array);
            string[] lines = textFromFile.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<Drinks> temp = new List<Drinks>();
            var DeserializersList = new DrinkDeserializersList();
            foreach (string line in lines)
            {
                string[] words = line.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach(TextDeserializer e in DeserializersList)
                {
                    if (e.Name == words[0])
                    {
                        temp.Add(e.Deserialize(words));
                        break;
                    }
                }
            }

            return temp;
        }
    }
}
