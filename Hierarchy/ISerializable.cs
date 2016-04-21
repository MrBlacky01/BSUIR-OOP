using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Hierarchy
{
    interface ISerializable
    {
        void Serialize(Stream stream,object element);
        object Deserialize(Stream stream, object element);
    }
}
