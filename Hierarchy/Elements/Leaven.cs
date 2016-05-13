using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public class Leaven : IEquatable<Leaven>
    {
        public int CountOfWater { get; set; }
        public rawMaterials RawMaterials { get; set; }
        public int CountOfMaterials { get; set; }
        public int CountOfYeast { get; set; }
        public int CountOfSugar { get; set; }

        public Leaven() { }

        public enum rawMaterials
        {
            wheat,
            barley,
            ginger
        }

        public Leaven(int water,int material,int materialCount, int yeast,int sugar)
        {
            CountOfWater = water;
            RawMaterials = (rawMaterials)Enum.GetValues(typeof(rawMaterials)).GetValue(material); ;
            CountOfMaterials = materialCount;
            CountOfYeast = yeast;
            CountOfSugar = sugar;
        }

        public  bool Equals(Leaven other)
        {
            if ((this.CountOfWater == other.CountOfWater) && (this.RawMaterials == other.RawMaterials) && (this.CountOfMaterials == other.CountOfMaterials)
                && (this.CountOfYeast == other.CountOfYeast) && (this.CountOfSugar == other.CountOfSugar))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return String.Format("W= {0}ml {1} {2}g Y= {3}g  S= {4}g",CountOfWater,RawMaterials,CountOfMaterials,CountOfYeast,CountOfSugar);
        }

        public  string ToText()
        {
            return String.Format("{0} {1} {2} {3} {4}", CountOfWater, (int)RawMaterials, CountOfMaterials, CountOfYeast, CountOfSugar); ;
        }
    }
}
