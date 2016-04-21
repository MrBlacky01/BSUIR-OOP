using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class VineDeserializer : TextDeserializer
    {
        
        public VineDeserializer()
        {
            Name = "Vine";
        }
        public override Drinks Deserialize(string[] words)
        {
            return new Vine(words[1], Convert.ToDouble(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]));
        }
    }
}
