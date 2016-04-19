using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public class Lemonade : Soft
    {
        
        public  int CountOfLemon { get; set; }

        public Lemonade() { }

        public Lemonade(string name, double volume, int lemons)
        {
            Name = name;
            Volume = volume;
            Carbonation = true;
            CountOfLemon = lemons;
            TypeName = "Lemonade";
        }

        public override bool Equals(Drinks v1)
        {

            Lemonade other = v1 as Lemonade;
            if ((other != null) && (this.Name == other.Name) && (this.Volume == other.Volume) && (this.CountOfLemon == other.CountOfLemon))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} V = {2:f1} Lemons Count {3}",TypeName,Name,Volume,CountOfLemon) ;
        }

        public override string ToText()
        {
            return String.Format("{0} {1} {2:f1} {3}", TypeName, Name, Volume, CountOfLemon);
        }
    }
}
