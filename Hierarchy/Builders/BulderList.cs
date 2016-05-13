using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class BuilderList : List<Builder>
    {
        public  BuilderList()
        {
            this.Add(new VineBuilder());
            this.Add(new BeerBuilder());
            this.Add(new CognacBuilder());
            this.Add(new MilkBuilder());
            this.Add(new KvassBuilder());
            this.Add(new LemonadeBuilder());
        }
    }
}
