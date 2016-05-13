using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class CognacDeserializer : TextDeserializer
    {

        public CognacDeserializer()
        {
            Name = "Cognac";
        }
        public override Drinks Deserialize(string[] words)
        {
            return new Cognac(words[1], Convert.ToDouble(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]));
        }
    
    }
}
