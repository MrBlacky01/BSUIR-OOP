using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class MilkDeserializer : TextDeserializer
    {

        public MilkDeserializer()
        {
            Name = "Milk";
        }
        public override Drinks Deserialize(string[] words)
        { 
            return new Milk(words[1], Convert.ToDouble(words[2]), Convert.ToDouble(words[3]));
        }
    
    }
}
