using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public abstract class Alcoholic : Drinks
    {
        public Alcoholic()
        { }
        public int PercentOfAlcohol { get; set; }

    }
}
