using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11Lab
{
    internal class Calculator
    {
        public static CalculatorState state;

        public static double num1;
        public static double num2;
        public static Operator operation;

        public Calculator()
        {
            state = new DigitOneState();
        }

        public void nextState(double num)
        {
            state.nextState(num);
        }

        public void nextState(Operator op)
        {
            state.nextState(op);
        }

        public void nextState(Equals eq)
        {
            state.nextState(eq);
        }
    }
}
