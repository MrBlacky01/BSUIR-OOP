using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy
{
    interface IBuildable
    {
         void MakingPanel(Panel panel, Builder.DAdd del);
        void ChangingElement(Panel panel,Drinks element, Builder.DChange del);
        void ClearPanel();

    }
}
