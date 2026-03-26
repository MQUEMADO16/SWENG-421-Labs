using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class CappuccinoProg : AbsProgram
    {
        public override void run()
        {
            base.coffeeMachine.setLEDNum(2);
            base.coffeeMachine.setGrindingTime(8);
            base.coffeeMachine.setTemperature(125);
            base.coffeeMachine.setLEDNum(-1);
        }
    }
}
