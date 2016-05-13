using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public class Beer : Alcoholic
    {
        public Leaven LeavenType { get; set; }

        public Beer() { }
        public Beer(string name, double volume,int percent, Leaven leavenType)
        {
            Name = name;
            Volume = volume;
            PercentOfAlcohol = percent;
            LeavenType = leavenType;
            TypeName = "Beer";
        }

        public override bool Equals(Drinks v1)
        {

            Beer other = v1 as Beer;
            if ((other != null) && (this.Name == other.Name) && (this.Volume == other.Volume) && (this.PercentOfAlcohol == other.PercentOfAlcohol)&&
                (this.LeavenType.ToString() == other.LeavenType.ToString()))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} V = {2:f1} Alco = {3}% Leaven: {4}", TypeName, Name, Volume, PercentOfAlcohol,LeavenType.ToString());
        }

        public override string ToText()
        {
           return String.Format("{0} {1} {2:f1} {3} {4}", TypeName, Name, Volume, PercentOfAlcohol, LeavenType.ToText());
        }
    }
}
