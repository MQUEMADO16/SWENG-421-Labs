using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class USBProg : AbsProgram
    {
        public override void run()
        {
            base.coffeeMachine.setLEDNum(3);
            base.coffeeMachine.setGrindingTime(5);
            base.coffeeMachine.setTemperature(200);
            base.coffeeMachine.setLEDNum(-1);
        }
    }
}
