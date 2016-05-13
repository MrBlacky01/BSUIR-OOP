using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class LemonadeDeserializer : TextDeserializer
    {

        public LemonadeDeserializer()
        {
            Name = "Lemonade";
        }
        public override Drinks Deserialize(string[] words)
        {
            return new Lemonade(words[1], Convert.ToDouble(words[2]), Convert.ToInt32(words[3]));
        }
    
    }
}
