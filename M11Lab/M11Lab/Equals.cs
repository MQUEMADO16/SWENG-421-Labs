using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M11Lab
{
    internal class Equals
    {
        public double result = 0;
        public double calc(double num1, double num2, Operator operation)
        {
            result = operation.calc(num1, num2);
            Console.WriteLine(result);
            return result;
        }
    }
}
