using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal abstract class AbsProgram : ProgramIF
    {
        public CMM? coffeeMachine;

        public void setMachine(CMM machine)
        {
            coffeeMachine = machine;
        }

        public abstract void run();
    }
}
