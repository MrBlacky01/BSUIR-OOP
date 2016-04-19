using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public abstract class Soft : Drinks
    {
        public Soft() { }
        public bool Carbonation{ get; set; }
    }
}
