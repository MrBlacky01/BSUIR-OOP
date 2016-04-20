using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class DictionaryForSerialize
    {
        public Dictionary<int,ISerializable> dict { get;private set; }

        public DictionaryForSerialize ()
        {
            dict = new Dictionary<int, ISerializable>();
            dict.Add(1, new XMLSerializerer());
            dict.Add(2, new BinarySerializerer());
            dict.Add(3, new TextSerializerer());

        }
    }
} 
