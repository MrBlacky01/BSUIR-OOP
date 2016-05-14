using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel.Composition;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class DeflateDecorator : SerializeDecorator
    {
        public DeflateDecorator(ISerializable component,string path) : base (component,path)
        { }

        public override void Serialize(Stream a, object b)
        {
            using (FileStream sourceStream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                _component.Serialize(sourceStream, b);
            }         
            using (FileStream sourceStream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                string compressedFile = _path + ".defl";
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    using (DeflateStream compressionStream = new DeflateStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
            File.Delete(_path);
        }

    }
}
