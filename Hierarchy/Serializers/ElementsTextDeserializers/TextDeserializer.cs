using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    abstract class TextDeserializer
    {

        public string Name { get; protected set; }
        public abstract Drinks Deserialize(string[] words);
    }
}
