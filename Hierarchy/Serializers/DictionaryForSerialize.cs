using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class DictionaryForSerialize
    {
        public Dictionary<string,ISerializable> dict { get; set; }

        public DictionaryForSerialize ()
        {
            dict = new Dictionary<string, ISerializable>();
            dict.Add("xml", new XMLSerializerer());
            dict.Add("dat", new BinarySerializerer());
            dict.Add("txt", new TextSerializerer());

        }
    }
} 
