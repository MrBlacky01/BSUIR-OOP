using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public class Vine: Alcoholic
    {
        public enum typesOfVine 
        {
            white,
            red,
            pink
        } 

        public typesOfVine vineType { get; set; }

        public Vine()
        { }

        public Vine(string name, double volume, int percent,int type)
        {
            Name = name;
            Volume = volume;
            PercentOfAlcohol = percent;
            vineType = (typesOfVine)Enum.GetValues(typeof(typesOfVine)).GetValue(type);
            TypeName = "Vine";
        }

        public override bool Equals (Drinks v1 )
        {
            
            Vine other = v1 as Vine;
            if ((other != null)&&(this.Name == other.Name)&&(this.PercentOfAlcohol == other.PercentOfAlcohol)&&(this.Volume == other.Volume)&&(this.vineType == other.vineType))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} V = {2:f1} Alco = {3}% Type {4}", TypeName, Name, Volume, PercentOfAlcohol, vineType);
        }

        public override string ToText()
        {
            return String.Format("{0} {1} {2:f1} {3} {4}", TypeName, Name, Volume, PercentOfAlcohol, Array.IndexOf(Enum.GetValues(vineType.GetType()), vineType));
        }
    }
}
