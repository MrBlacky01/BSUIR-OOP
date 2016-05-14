using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hierarchy
{
    class ClearReceiver
    {
        int selectedItem;
        string filename;
        List<Drinks> ListOfDrinks;
        string archivateIndex;
        DictionaryForSerialize Serializers;

        public ClearReceiver(int _selectedItem,string _filename,List<Drinks> _List,string _archIndex, DictionaryForSerialize temp )
        {
            selectedItem = _selectedItem;
            filename = _filename;
            ListOfDrinks = _List;
            archivateIndex = _archIndex;
            Serializers = temp;
        }

        public void Operation()
        {
            string extension = GetExtension(filename);
            try
            {
                if (selectedItem == 1)
                {
                    ISerializable temp = Serializers.dict[extension.ToString()];
                    temp = new DeflateDecorator(temp, filename);
                    temp.Serialize(new MemoryStream(), ListOfDrinks);
                    return;
                }
                else
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        Serializers.dict[extension.ToString()].Serialize(fs, ListOfDrinks);
                    }
                }
                if (archivateIndex != null)
                {
                    Serializers.dict[archivateIndex].Serialize(new MemoryStream(), filename);
                }
            }
            catch (Exception exept1)
            {
                MessageBox.Show(exept1.Message.ToString());
            }
        }

        private string GetExtension(string name)
        {
            StringBuilder extension = new StringBuilder(name);
            int i;
            for (i = extension.Length - 1; i > 0; i--)
            {
                if (extension[i] == '.')
                {
                    break;
                }
            }
            extension.Remove(0, i + 1);
            return extension.ToString();
        }
    }
}
