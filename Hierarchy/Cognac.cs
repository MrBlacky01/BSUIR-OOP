using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public class Cognac : Alcoholic
    {
        public int Age { get; set; }

        public Cognac() { }
        public Cognac(string name, double volume, int percent, int age)
        {
            Name = name;
            Volume = volume;
            PercentOfAlcohol = percent;
            Age = age;
            TypeName = "Cognac";
        }

        public override bool Equals(Drinks v1)
        {

            Cognac other = v1 as Cognac;
            if ((other != null) && (this.Name == other.Name) && (this.Volume == other.Volume)&&(this.PercentOfAlcohol == other.PercentOfAlcohol)&&(this.Age == other.Age))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} V = {2:f1} Alco = {3}% Age = {4}", TypeName, Name, Volume, PercentOfAlcohol,Age);
        }

        public override string ToText()
        {
            return String.Format("{0} {1} {2:f1} {3} {4}", TypeName, Name, Volume, PercentOfAlcohol, Age);
        }
    }
}
