using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class BeerDeserializer : TextDeserializer
    {

        public BeerDeserializer()
        {
            Name = "Beer";
        }
        public override Drinks Deserialize(string[] words)
        {
            Leaven temp = new Leaven(Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7]), Convert.ToInt32(words[8]));
            return new Beer(words[1], Convert.ToDouble(words[2]), Convert.ToInt32(words[3]), temp);
        }
    
    }
}
