using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy
{
    class KvassBuilder: LeavenBuilder
    {
        public override void MakingPanel(Panel panel, DAdd del)
        {
            delToAdd = del;

            MakingTemplate(panel);
            MakingYealdPanel(panel);

            save.MouseClick += MakingObject;

        }

        public KvassBuilder()
        {
            Name = "Kvass";
        }

        public override void ClearPanel()
        {
            DisposeLeavenPanel();
            ClearPartOfPanel();
        }

        public override void ChangingElement(Panel panel, Drinks element, DChange del)
        {
            Kvass temp = element as Kvass;
            nameBox.Text = element.Name;
            volume.Value = Convert.ToDecimal(element.Volume);

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
                if ((nameBox.Text.Trim()).Length == 0) throw new Exception("Please, enter name of drink");
                Kvass template = new Kvass(nameBox.Text.Trim(), Convert.ToDouble(volume.Value), newLeaven);
                ChooseAction(template);

            }
            catch (FormatException exept)
            {
                MessageBox.Show("Please, enter correct information about leaven ");
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
