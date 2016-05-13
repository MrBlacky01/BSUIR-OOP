using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Text;


using InterfacePlugin;

namespace Hierarchy
{

    public partial class HierarchyForm : Form
    {
        
        public List<Drinks> ListOfDrinks = new List<Drinks>();
        [ImportMany(typeof(IPlugin))]
        List<IPlugin> Plugins { get; set; }
        

        BuilderList buildList = new BuilderList();
        int index;
        int indexForChange;
        bool afterChangebuttonAdd;
        DictionaryForSerialize Serializers = new DictionaryForSerialize();
        List<string> ArchivateExtensions = new List<string>();

        public HierarchyForm()
        {
            InitializeComponent();
            AdditingElementsToCombobox();
            panelForActions.Enabled = false;
            comboBoxForArhivate.Items.Add("<Without>");
            comboBoxForArhivate.SelectedIndex = 0;
            /* DirectoryCatalog m_catalog = new DirectoryCatalog("Plugins");
             CompositionContainer container = new CompositionContainer(m_catalog);
             container.ComposeParts(this);
             */
            AddPlugins();
      
           
        }

        private void AddPlugins()
        {
            DirectoryCatalog m_catalog = new DirectoryCatalog("Plugins");
            CompositionContainer container = new CompositionContainer(m_catalog);
            container.ComposeParts(this);

            if (Plugins == null) return;

            foreach (var plugin in Plugins)
            {
                comboBoxForArhivate.Items.Add(plugin.Name);
                ArchivateExtensions.Add(plugin.Exe);
                openFileDialog1.Filter += "|" + plugin.Name + "|*." + plugin.Exe;
            }
        }

        public void AdditingElementsToCombobox()
        {
            foreach (Builder item in buildList)
            {
                comboBoxDrinks.Items.Add(item.Name);

            }
        }

        public void AddElementToList(Drinks element)
        {
            if (ListOfDrinks.Contains(element) == false)
            {
                listBoxForDrinks.Items.Add(element.ToString());
                ListOfDrinks.Add(element);
                MessageBox.Show("Drink has been succesfully added");
                buildList[comboBoxDrinks.SelectedIndex].ClearPanel();
                panelForActions.Enabled = false;
               comboBoxDrinks.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Sorry,but drink has been already added");
            }
        }

        private void buttonAdding_Click(object sender, EventArgs e)
        {
            if (comboBoxDrinks.SelectedIndex != -1)
            {
                buildList[comboBoxDrinks.SelectedIndex].ClearPanel();
                panelForActions.Enabled = false;
                comboBoxDrinks.SelectedIndex = -1;
            }
            panelForActions.Enabled = true;
            comboBoxDrinks.Enabled = true;
            afterChangebuttonAdd = false;
        }

        private void comboBoxDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrinks.SelectedIndex != -1)
            {
                if (index < 0)
                    index = comboBoxDrinks.SelectedIndex;

                if (index != comboBoxDrinks.SelectedIndex)
                {
                    if (!afterChangebuttonAdd)
                        buildList[index].ClearPanel();
                    index = comboBoxDrinks.SelectedIndex;
                }
                Builder.DAdd temp = AddElementToList;
                buildList[comboBoxDrinks.SelectedIndex].MakingPanel(panelForActions, temp);
            }
            
            
        }

        private void buttonRemoving_Click(object sender, EventArgs e)
        {
            if (listBoxForDrinks.SelectedIndex != -1 )
            {
                ListOfDrinks.RemoveAt(listBoxForDrinks.SelectedIndex);
                listBoxForDrinks.Items.RemoveAt(listBoxForDrinks.SelectedIndex);
            }
          
            
        }

        private void buttonChanging_Click(object sender, EventArgs e)
        {
            if (listBoxForDrinks.SelectedIndex != -1 )
            {
                string type = ListOfDrinks[listBoxForDrinks.SelectedIndex].TypeName;
                afterChangebuttonAdd = true;
                int i;
                for (i =0; i < buildList.Count; i++)
                {
                    if (buildList[i].Name == type)
                    {
                        if (comboBoxDrinks.SelectedIndex != -1)
                        {
                            buildList[comboBoxDrinks.SelectedIndex].ClearPanel();
                        }
                        panelForActions.Enabled = true;
                        comboBoxDrinks.SelectedIndex = i;
                        indexForChange = listBoxForDrinks.SelectedIndex;
                        comboBoxDrinks.Enabled = false;
                        buildList[i].ChangingElement(panelForActions, ListOfDrinks[indexForChange], ChangeElement);
                        break;
                    }
                }
                
            }
        }

        public void ChangeElement(Drinks element)
        {
            if (ListOfDrinks.Contains(element) == false)
            {
                listBoxForDrinks.Items[indexForChange] = element.ToString();
                ListOfDrinks[indexForChange]=(element);
                MessageBox.Show("Drink has been succesfully changed");
                buildList[comboBoxDrinks.SelectedIndex].ClearPanel();
                comboBoxDrinks.Enabled = true;
                panelForActions.Enabled = false;
                comboBoxDrinks.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Sorry,but drink has been already added");
            }
        }

        

        

        private void buttonSerialize_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;           
            int archivateIndex = comboBoxForArhivate.SelectedIndex;
            string filename =  saveFileDialog1.FileName;
            StringBuilder extension = new StringBuilder(filename);
            int i;
            for ( i = extension.Length-1; i>0; i--)
            {
                if (extension[i] == '.')
                {
                    break;
                }
            }
            extension.Remove(0, i+1);
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                     
                    Serializers.dict[extension.ToString()].Serialize(fs, ListOfDrinks);   
                }
                if (archivateIndex > 0)
                {
                    Plugins[archivateIndex - 1].Archivate(filename);
                }
            }
            catch (Exception exept1)
            {
                MessageBox.Show(exept1.Message.ToString());
            }
        }

        private void buttonDesirealize_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            bool isArchivated = false;
            StringBuilder filename = new StringBuilder( openFileDialog1.FileName);
            StringBuilder extension = new StringBuilder(filename.ToString());
            int i;
            for (i = extension.Length - 1; i > 0; i--)
            {
                if (extension[i] == '.')
                {
                    break;
                }
            }
            extension.Remove(0, i + 1);
            if ( ArchivateExtensions.Contains(extension.ToString()))
            {
                for (int j = 0; j < Plugins.Count;j++)
                {
                    if (Plugins[j].Exe == extension.ToString())
                    {
                        Plugins[j].Dearchivate(filename.ToString());
                        filename.Replace("."+extension.ToString(), "");
                        extension = new StringBuilder(filename.ToString());
                        isArchivated = true; 
                        for (i = extension.Length - 1; i > 0; i--)
                        {
                            if (extension[i] == '.')
                            {
                                break;
                            }
                        }
                        extension.Remove(0, i + 1);
                    }
                }
            }
            try
            {
                if (Serializers.dict.ContainsKey(extension.ToString()) == false) throw new Exception("Unnown type for deserialize ");
                using (FileStream fs = new FileStream(filename.ToString(), FileMode.OpenOrCreate))
                {
                        ListOfDrinks = (List<Drinks>)Serializers.dict[extension.ToString()].Deserialize(fs, ListOfDrinks); 
                        AddElementsToListBoxAfterDeserialization();
                }
                if (isArchivated )
                {
                    File.Delete(filename.ToString());
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message.ToString());
            }
            
        }

        private void AddElementsToListBoxAfterDeserialization()
        {
            listBoxForDrinks.Items.Clear();
            foreach (Drinks element in ListOfDrinks)
            {
                listBoxForDrinks.Items.Add(element.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListOfDrinks.Clear();
            listBoxForDrinks.Items.Clear();
        }
    }
}
