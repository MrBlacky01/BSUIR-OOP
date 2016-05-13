using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy
{
    class BeerBuilder : LeavenBuilder
    {

  
        public override void MakingPanel(Panel panel, DAdd del)
        {
            delToAdd = del;
            MakingAlcoPanel(panel, 105, 100);
            MakingYealdPanel(panel);

            save.MouseClick += MakingObject;
        }

        public BeerBuilder()
        {
            Name = "Beer";
        }

        public override void ClearPanel()
        {
            DisposeLeavenPanel();
            DisposeAlcoPanel();
        }

        public override void ChangingElement(Panel panel, Drinks element, DChange del)
        {
            Beer temp = element as Beer;
            nameBox.Text = element.Name;
            volume.Value = Convert.ToDecimal(element.Volume);
            percentBox.Text = temp.PercentOfAlcohol.ToString();
            ChangingLeavenElement(temp.LeavenType);


            this.save.Text = "Change Object";

            delToAdd = null;
            delToChange = del;
        }


        private void MakingObject(object sender, EventArgs e)
        {
            try
            {
                Leaven newLeaven = MakingLeavenObject();
                if (newLeaven == null) throw new Exception("Please, enter leave fields ");

                if ((nameBox.Text.Trim()).Length == 0) throw new Exception("Please, enter name of drink");
                if ((Convert.ToInt32(percentBox.Text) > 70) || (Convert.ToInt32(percentBox.Text) < 0)) throw new FormatException();
                Beer template = new Beer(nameBox.Text.Trim(), Convert.ToDouble(volume.Value), Convert.ToInt32(percentBox.Text), newLeaven);
                ChooseAction(template);
            }
            catch (FormatException exept)
            {
                MessageBox.Show("Please enter correct percent of alcohol");
            }
            catch (ArgumentOutOfRangeException exept)
            {

            }
            catch (Exception exept)
            {
                if (exept.Message.Length > 0)
                    MessageBox.Show(exept.Message);
            }

        }
    }
}
