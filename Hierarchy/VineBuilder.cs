using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy
{
    class VineBuilder : Builder
    {

        ComboBox types;
        Label typesLabel;

        private void MakingVinePanelPart(Panel panel)
        {
            types = new ComboBox();
            typesLabel = new Label();

            panel.Controls.Add(types);
            panel.Controls.Add(typesLabel);

            types.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            types.FormattingEnabled = true;
            types.Items.AddRange(new object[] {
            Vine.typesOfVine.white,
            Vine.typesOfVine.red,
            Vine.typesOfVine.pink});
            types.Location = new System.Drawing.Point(180, 232);
            types.Size = new System.Drawing.Size(181, 21);
            types.TabIndex = 7;

            typesLabel.AutoSize = true;
            typesLabel.Location = new System.Drawing.Point(45, 235);
            typesLabel.Name = "label4";
            typesLabel.Size = new System.Drawing.Size(52, 13);
            typesLabel.TabIndex = 8;
            typesLabel.Text = "Vine Type";
        }

        public override void ChangingElement(Panel panel, Drinks element, DChange del)
        {
            Vine temp = element as Vine;
            nameBox.Text = element.Name;
            volume.Value = Convert.ToDecimal(element.Volume);
            percentBox.Text = temp.PercentOfAlcohol.ToString();
            types.SelectedItem = temp.vineType;

            this.save.Text = "Change Object";
          
            delToAdd = null;
            delToChange = del;           
        }

        public override void MakingPanel (Panel panel, DAdd del)
        {
  
            MakingAlcoPanel(panel, 184, 181);
            delToAdd = del;
            MakingVinePanelPart(panel);
            save.MouseClick += new MouseEventHandler(MakingObject);

        }

        public VineBuilder()
        {
            Name = "Vine";
        }

        public override void ClearPanel()
        {
            DisposeAlcoPanel();
             types.Dispose();
             typesLabel.Dispose();
               
        }

        private void MakingObject(object sender, EventArgs e)
        {
            try 
            {
                if ((nameBox.Text.Trim()).Length == 0) throw new Exception("Please, enter name of drink");
                if  ((Convert.ToInt32(percentBox.Text) > 40) || (Convert.ToInt32(percentBox.Text) < 0)) throw new FormatException();
                if (types.SelectedIndex == -1) throw new Exception("Please, choose the type");
                Vine template = new Vine(nameBox.Text.Trim().ToString(), Convert.ToDouble( volume.Value), Convert.ToInt32(percentBox.Text),types.SelectedIndex);
                ChooseAction(template);
                           
            }
            catch(FormatException exept)
            {
                MessageBox.Show("Please enter correct percent of alcohol");
            }
            catch(ArgumentOutOfRangeException exept)
            {

            }
            catch(Exception exept)
            {
                MessageBox.Show(exept.Message);
            }

        }

    }
}
