using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    [Serializable]
    public class Kvass: Soft
    {
        public Leaven LeavenType { get; set; }

        public Kvass() { }
        public Kvass(string name, double volume, Leaven leavenType)
        {
            Name = name;
            Volume = volume;
            Carbonation = true;
            LeavenType = leavenType;
            TypeName = "Kvass";
        }

        public override bool Equals(Drinks v1)
        {

            Kvass other = v1 as Kvass;
            if ((other != null) && (this.Name == other.Name) && (this.Volume == other.Volume) && (this.LeavenType.ToString() == other.LeavenType.ToString()))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} V = {2:f1} Leaven: {3}", TypeName, Name, Volume, LeavenType.ToString());
        }

        public override string ToText()
        {
            return String.Format("{0} {1} {2:f1} {3}", TypeName, Name, Volume, LeavenType.ToText());
        }

    }
}
