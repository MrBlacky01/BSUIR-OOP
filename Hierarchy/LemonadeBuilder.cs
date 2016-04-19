using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy
{
    class LemonadeBuilder : Builder
    {

        public NumericUpDown CountOfLemons;
        public Label CountOfLemonsLabel;

        private void MakingLemonadePanelPart(Panel panel)
        {
            CountOfLemons = new NumericUpDown();
            CountOfLemonsLabel = new Label();

            panel.Controls.Add(CountOfLemons);
            panel.Controls.Add(CountOfLemonsLabel);

            CountOfLemons.Location = new System.Drawing.Point(242, 190);
            CountOfLemons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            CountOfLemons.Name = "numericUpDown2";
            CountOfLemons.Size = new System.Drawing.Size(67, 20);
            CountOfLemons.TabIndex = 1;
            CountOfLemons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            CountOfLemonsLabel.AutoSize = true;
            CountOfLemonsLabel.Location = new System.Drawing.Point(45, 190);
            CountOfLemonsLabel.Name = "label4";
            CountOfLemonsLabel.Size = new System.Drawing.Size(42, 13);
            CountOfLemonsLabel.TabIndex = 3;
            CountOfLemonsLabel.Text = "Count of lemons on portion";
        }


        public override void MakingPanel(Panel panel, DAdd del)
        {
            MakingTemplate(panel);
            delToAdd = del;
            MakingLemonadePanelPart(panel);
            

            save.MouseClick += new MouseEventHandler(MakingObject);
        }

        public LemonadeBuilder()
        {
            Name = "Lemonade";
        }

        public override void ClearPanel()
        {
            ClearPartOfPanel();

            CountOfLemons.Dispose();
            CountOfLemonsLabel.Dispose();

        }

        public override void ChangingElement(Panel panel, Drinks element, DChange del)
        {
            Lemonade temp = element as Lemonade;
            nameBox.Text = element.Name;
            volume.Value = Convert.ToDecimal(element.Volume);
            CountOfLemons.Value = Convert.ToDecimal(temp.CountOfLemon);

            this.save.Text = "Change Object";

            delToAdd = null;
            delToChange = del;
        }

        private void MakingObject(object sender, EventArgs e)
        {
            try
            {
                if ((nameBox.Text.Trim()).Length == 0) throw new Exception("Please, enter name of drink");
                if ((Convert.ToInt32(CountOfLemons.Text) > 20) ) throw new Exception("So much lemos, it very sour :D");
                Lemonade template = new Lemonade(nameBox.Text.Trim().ToString(), Convert.ToDouble(volume.Value), Convert.ToInt32(CountOfLemons.Text));
                ChooseAction(template);
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
