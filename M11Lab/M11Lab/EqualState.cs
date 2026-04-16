using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11Lab
{
    internal class EqualState : CalculatorState
    {
        public override void nextState(double num)
        {
            // SWITCH TO DIGIT ONE STATE
            Calculator.num1 = num;
            Calculator.num2 = 0;
            Calculator.state = new DigitOneState();
        }

        public override void nextState(Operator operation)
        {   
            // SWITCH TO OPERATOR STATE
            Calculator.operation = operation;
            Calculator.state = new OperatorState();
        }
        public override void nextState(Equals equal)
        {   
            // STAY IN EQUAL STATE
            double result = Calculator.operation.calc(
                Calculator.num1,
                Calculator.lastOperand
            );

            Calculator.num1 = result;
            equal.result = result;
        }
    }
}
