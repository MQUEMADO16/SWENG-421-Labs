using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class MochaProg : AbsProgram
    {
        public override void run()
        {
            base.coffeeMachine.setLEDNum(1);
            base.coffeeMachine.setGrindingTime(8);
            base.coffeeMachine.setTemperature(150);
            base.coffeeMachine.setLEDNum(-1);
        }
    }
}
