using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hierarchy
{
    class SerializeDecorator : ISerializable
    {
        protected ISerializable _component;
        protected string _path;

        public SerializeDecorator(ISerializable component, string path)
        {
            _component = component;
            _path = path;
        }
        public virtual void Serialize(Stream a, object b)
        {

        }

        public virtual object Deserialize(Stream a, object b)
        {

            return b;
        }
    }
}
