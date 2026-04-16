using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11Lab
{
    internal class OperatorState : CalculatorState
    {
        public override void nextState(double num)
        {
            Calculator.num2 = num;
            Calculator.state = new DigitTwoState();
        }
        public override void nextState(Operator operation)
        {
            Calculator.operation = operation;
        }

        public override void nextState(Equals equals)
        {
            // no implementation neccessary since we still need num 2
        }
    }
}
