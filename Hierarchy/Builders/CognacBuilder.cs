using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Hierarchy
{
    class CognacBuilder :Builder
    {

        TextBox ageBox;
        Label ageLabel;
        private void MakingCognacPanelPart(Panel panel)
        {
            ageBox = new TextBox();
            ageLabel = new Label();

            panel.Controls.Add(ageBox);
            panel.Controls.Add(ageLabel);

            ageLabel.AutoSize = true;
            ageLabel.Location = new System.Drawing.Point(45, 235);
            ageLabel.Name = "label4";
            ageLabel.Size = new System.Drawing.Size(95, 13);
            ageLabel.TabIndex = 7;
            ageLabel.Text = "Age";

            ageBox.Location = new System.Drawing.Point(242, 232);
            ageBox.Name = "textBox4";
            ageBox.Size = new System.Drawing.Size(67, 20);
            ageBox.TabIndex = 8;

        }

        public override void MakingPanel(Panel panel, DAdd del)
        {

            MakingAlcoPanel(panel, 184, 181);
            delToAdd = del;
            MakingCognacPanelPart(panel);
            save.MouseClick += new MouseEventHandler(MakingObject);


        }

        public CognacBuilder()
        {
            Name = "Cognac";
        }

        public override void ClearPanel()
        {
            DisposeAlcoPanel();
            ageBox.Dispose();
            ageLabel.Dispose();
            
        }

        public override void ChangingElement(Panel panel, Drinks element, DChange del)
        {
            Cognac temp = element as Cognac;
            nameBox.Text = element.Name;
            volume.Value = Convert.ToDecimal(element.Volume);
            percentBox.Text = temp.PercentOfAlcohol.ToString();
            ageBox.Text = temp.Age.ToString();

            this.save.Text = "Change Object";

            delToAdd = null;
            delToChange = del;
        }

        private void MakingObject(object sender, EventArgs e)
        {
            try
            {
                if ((nameBox.Text.Trim()).Length == 0) throw new Exception("Please, enter name of drink");
                if ( (Convert.ToInt32(percentBox.Text) > 90) || (Convert.ToInt32(percentBox.Text) < 0) ) throw new Exception("Please, enter correct percent of alcohol");
                if ( (Convert.ToInt32(ageBox.Text) > 200) || (Convert.ToInt32(ageBox.Text) < 0) ) throw new Exception("Please, enter correct age of cognac");
                Cognac template = new Cognac(nameBox.Text.Trim().ToString(), Convert.ToDouble(volume.Value), Convert.ToInt32(percentBox.Text),Convert.ToInt32(ageBox.Text));
                ChooseAction(template);
            }
            catch (FormatException exept)
            {
                MessageBox.Show("Please, enter correct percent of alcohol or age ");
            }
            catch (ArgumentOutOfRangeException exept)
            {

            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message);
            }

        }
    }
}
