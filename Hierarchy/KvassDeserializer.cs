using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class KvassDeserializer : TextDeserializer
    {

        public KvassDeserializer()
        {
            Name = "Kvass";
        }
        public override Drinks Deserialize(string[] words)
        {
            Leaven temp = new Leaven(Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7]));
            return new Kvass(words[1], Convert.ToDouble(words[2]), temp);
        }
    
    }
}
