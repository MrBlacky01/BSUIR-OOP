using System.IO;

namespace InterfacePlugin
{
    public interface IPlugin
    {
        void Archivate(Stream stream, string path);
        void Dearchivate(Stream stream);
        string Name { get; }
        string Exe { get; }
    }
}
