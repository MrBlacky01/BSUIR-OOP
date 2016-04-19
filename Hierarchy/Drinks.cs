using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hierarchy
{
    [Serializable]
    [XmlInclude(typeof(Beer)), XmlInclude(typeof(Cognac)), XmlInclude(typeof(Kvass)), XmlInclude(typeof(Lemonade)), XmlInclude(typeof(Milk)), XmlInclude(typeof(Vine))]
    public abstract class Drinks: IEquatable<Drinks>
    {
        public Drinks()
        { }
        public string Name { get; set; }
        public double Volume { get; set; }
        public string TypeName { get;  set; }
        public abstract bool Equals(Drinks other);
        public abstract string ToText();
    }
}
