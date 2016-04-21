using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class DrinkDeserializersList : List<TextDeserializer>
    {
        public DrinkDeserializersList()
        {
            this.Add(new VineDeserializer());
            this.Add(new CognacDeserializer());
            this.Add(new BeerDeserializer());
            this.Add(new MilkDeserializer());
            this.Add(new KvassDeserializer());
            this.Add(new LemonadeDeserializer());
        }
    }
}
