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
            Calculator.lastOperator = operation;
        }

        public override void nextState(Equals equals)
        {
            Calculator.num2 = Calculator.lastOperand;
            double result = equals.calc(Calculator.num1, Calculator.num2, Calculator.operation);
            Calculator.num1 = result;
            Calculator.lastOperand = Calculator.num2;
            Calculator.state = new EqualState();

        }
    }
}
