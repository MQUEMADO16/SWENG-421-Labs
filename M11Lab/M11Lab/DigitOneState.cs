using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace M11Lab
{
    internal class DigitOneState : CalculatorState
    {
        public override void nextState(double num)
        {   
            // STAY IN DIGIT ONE STATE
            Calculator.num1 = Calculator.num1 * 10 + num;
        }

        public override void nextState(Operator operation)
        {   
            // SWITCH TO OPERATOR STATE
            Calculator.operation = operation;
            Calculator.lastOperator = operation;
            Calculator.lastOperand = Calculator.num1;
            Calculator.state = new OperatorState();
        }

        public override void nextState(Equals equal)
        {
            // no operation necessary on digit one
        }
    }
}
