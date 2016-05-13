using System.IO;

namespace InterfacePlugin
{
    public interface IPlugin
    {
        void Archivate(string path);
        void Dearchivate(string stream);
        string Name { get; }
        string Exe { get; }
    }
}
