using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public class Milk : Soft
    {
        public  double Fatness { get; set; }
        public Milk() { }

        public Milk(string name, double volume, double fatness)
        {
            Name = name;
            Volume = volume;
            Carbonation = false;
            Fatness = fatness;
            TypeName = "Milk";
        }

        public override bool Equals(Drinks v1)
        {

            Milk other = v1 as Milk;
            if ((other != null) && (this.Name == other.Name) && (this.Volume == other.Volume)&&(this.Fatness == other.Fatness))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} V = {2:f1} Fatness {3:f1}", TypeName, Name, Volume, Fatness);
        }

        public override string ToText()
        {
            return String.Format("{0} {1} {2:f1} {3:f1}", TypeName, Name, Volume, Fatness);
        }
    }
}
