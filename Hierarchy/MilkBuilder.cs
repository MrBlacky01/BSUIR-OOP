using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Hierarchy
{
    class MilkBuilder : Builder
    {
        public NumericUpDown Featness;
        public Label FeatnessLabel;

        private void MakingMilkPanelPart(Panel panel)
        {
            Featness = new NumericUpDown();
            FeatnessLabel = new Label();

            panel.Controls.Add(Featness);
            panel.Controls.Add(FeatnessLabel);

            Featness.DecimalPlaces = 1;
            Featness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            Featness.Location = new System.Drawing.Point(242, 190);
            Featness.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            Featness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            Featness.Name = "numericUpDown1";
            Featness.Size = new System.Drawing.Size(67, 20);
            Featness.TabIndex = 1;
            Featness.ThousandsSeparator = true;
            Featness.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});

            FeatnessLabel.AutoSize = true;
            FeatnessLabel.Location = new System.Drawing.Point(45, 190);
            FeatnessLabel.Name = "label4";
            FeatnessLabel.Size = new System.Drawing.Size(42, 13);
            FeatnessLabel.TabIndex = 3;
            FeatnessLabel.Text = "Fatness Of Milk";

        }

        public override void MakingPanel(Panel panel, DAdd del)
        {

            MakingTemplate(panel);
            delToAdd = del;
            MakingMilkPanelPart(panel);
            
            save.MouseClick += new MouseEventHandler(MakingObject);
        }

        public MilkBuilder()
        {
            Name = "Milk";
        }

        public override void ClearPanel()
        {
            ClearPartOfPanel();
       
            Featness.Dispose();
            FeatnessLabel.Dispose();
        }

        public override void ChangingElement(Panel panel, Drinks element, DChange del)
        {
            Milk temp = element as Milk;
            nameBox.Text = element.Name;
            volume.Value = Convert.ToDecimal(element.Volume);
            Featness.Value = Convert.ToDecimal(temp.Fatness);
        
            this.save.Text = "Change Object";

            delToAdd = null;
            delToChange = del;
        }

        private void MakingObject(object sender, EventArgs e)
        {
            try
            {
                if ((nameBox.Text.Trim()).Length == 0) throw new Exception("Please, enter name of drink");
                Milk template = new Milk(nameBox.Text.Trim().ToString(), Convert.ToDouble(volume.Value), Convert.ToDouble(Featness.Value));

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
