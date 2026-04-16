using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11Lab
{
    internal abstract class CalculatorState
    {
        public static Calculator calculator;
        public double num1;
        public double num2;
        public Operator operation;

        public void nextOperation(Operator operation)
        {
            this.operation = operation;
        }
    }
}
