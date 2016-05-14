using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using InterfacePlugin;


namespace Hierarchy
{
    class ArchivatorToSerializatorAdapter :ISerializable
    {
        IPlugin element;
        string path;
        public ArchivatorToSerializatorAdapter(IPlugin c)
        {
            element = c;
        }

        public void Serialize(Stream a, object b)
        {
            path = (string)b;
            element.Archivate(path);
        }

        public object Deserialize(Stream a, object b)
        {
            path = (string)b;
            element.Dearchivate(path);
            return b;
        }
    }
}
