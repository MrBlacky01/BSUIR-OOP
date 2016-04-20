using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hierarchy
{

    public partial class HierarchyForm : Form
    {
        
        public List<Drinks> ListOfDrinks = new List<Drinks>();

        BuilderList buildList = new BuilderList();
        int index;
        int indexForChange;
        bool afterChangebuttonAdd;

        public HierarchyForm()
        {
            InitializeComponent();
            AdditingElementsToCombobox();
            panelForActions.Enabled = false;
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
            string filename = saveFileDialog1.FileName;
            int exe = saveFileDialog1.FilterIndex;
            try
            {


                switch (exe)
                {
                    case 1:
                        {
                            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                            {
                                XmlSerializer serializer = new XmlSerializer(ListOfDrinks.GetType());                               
                                serializer.Serialize(fs, ListOfDrinks);                                
                            }
                            break;
                        }
                    case 2:
                        {
                            BinaryFormatter formatter = new BinaryFormatter();

                            using (FileStream fs = new FileStream(filename, FileMode.Create))
                            {
                                
                                formatter.Serialize(fs, ListOfDrinks);
                            }
                            break;
                        }
                    case 3:
                        {
                            using (StreamWriter fs = new StreamWriter(filename))
                            {
                                foreach (Drinks el in ListOfDrinks)
                                {
                                    //byte[] array = System.Text.Encoding.Default.GetBytes(el.ToText()+"\n");
                                    // запись массива байтов в файл
                                    fs.WriteLine(el.ToText());
                                }
                            }
                            break;
                        }

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
            string filename = openFileDialog1.FileName;
            int exe = openFileDialog1.FilterIndex;
           /* //IDictionary<int, ISeril> dict
            //Dict by index serializer

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                //serializer.Serialize()
            }
            */
            try
            {
                switch (exe)
                {
                    case 1:
                        {
                            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                            {
                                XmlSerializer serializer = new XmlSerializer(ListOfDrinks.GetType());
                                ListOfDrinks = (List<Drinks>)serializer.Deserialize(fs);
                                listBoxForDrinks.Items.Clear();
                                foreach(Drinks element in ListOfDrinks)
                                {

                                    listBoxForDrinks.Items.Add(element.ToString());
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                            {
                                ListOfDrinks = (List<Drinks>)formatter.Deserialize(fs);
                                listBoxForDrinks.Items.Clear();
                                foreach (Drinks element in ListOfDrinks)
                                {

                                    listBoxForDrinks.Items.Add(element.ToString());
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            using (FileStream fstream = File.OpenRead(filename))
                            {
                                byte[] array = new byte[fstream.Length];
                                fstream.Read(array, 0, array.Length);
                                string textFromFile = System.Text.Encoding.Default.GetString(array);
                                string[] lines = textFromFile.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach(string line in lines)
                                {
                                    string[] words = line.Split(new char[] { ' ','\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
                                    Drinks element= new Vine(); 
                                    switch (words[0])
                                    {
                                        case "Vine":
                                            {
                                                string a = words[1];
                                                double b = Convert.ToDouble(words[2]);
                                                int c = Convert.ToInt32(words[3]);
                                                int d = Convert.ToInt32(words[4]);
                                                element = new Vine(a, b, c, d);
                                               // element = new Vine(words[1],Convert.ToDouble(words[2]),Convert.ToInt32( words[3]), Convert.ToInt32(words[4]));
                                                break;
                                            }
                                        case "Beer":
                                            {
                                                Leaven temp = new Leaven(Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7]), Convert.ToInt32(words[8]));
                                                element = new Beer(words[1], Convert.ToDouble(words[2]), Convert.ToInt32(words[3]), temp);
                                                break;
                                            }
                                        case "Cognac":
                                            {
                                                element = new Cognac(words[1], Convert.ToDouble(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]));
                                                break;
                                            }
                                        case "Kvass":
                                            {
                                                Leaven temp = new Leaven(Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7]));
                                                element = new Kvass(words[1], Convert.ToDouble(words[2]), temp);
                                                break;
                                            }
                                        case "Milk":
                                            {
                                                element = new Milk(words[1], Convert.ToDouble(words[2]), Convert.ToDouble(words[3]));
                                                break;
                                            }
                                        case "Lemonade":
                                            {
                                                element = new Lemonade(words[1], Convert.ToDouble(words[2]), Convert.ToInt32(words[3]));
                                                break;
                                            }

                                    }
                                    ListOfDrinks.Add(element);
                                    listBoxForDrinks.Items.Add(element.ToString());
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListOfDrinks.Clear();
            listBoxForDrinks.Items.Clear();
        }
    }
}
