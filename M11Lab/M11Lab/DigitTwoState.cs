using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace M11Lab
{
    internal class DigitTwoState : CalculatorState
    {
        public override void nextState(double num)
        {
            Calculator.num2 = Calculator.num2 * 10 + num;
        }

        public override void nextState(Operator operation)
        {
            double result = Calculator.operation.calc(Calculator.num1, Calculator.num2);
            Calculator.num1 = result;
            Calculator.num2 = 0;
            Calculator.operation = operation;
            Calculator.state = new OperatorState();
        }

        public override void nextState(Equals equal)
        {
            double result = Calculator.operation.calc(Calculator.num1, Calculator.num2);
            Calculator.num1 = result;
            Calculator.num2 = 0;
            Calculator.state = new EqualState();
            equal.result = result;
        }
    }
}