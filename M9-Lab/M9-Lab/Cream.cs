using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class Cream : CondimentIF
    {
        private static double price = 0.25;

        public static double computePrice()
        {
            return price;
        }
    }
}
