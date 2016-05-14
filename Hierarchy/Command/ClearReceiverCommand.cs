using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    class ClearReceiverCommand :ICommand
    {
        ClearReceiver _receiver;
        public ClearReceiverCommand(ClearReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Operation();
        }

    }
}
