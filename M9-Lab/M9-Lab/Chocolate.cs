using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class Chocolate : CondimentIF
    {
        private static double price = 1.00;

        public static double computePrice()
        {
            return price;
        }
    }
}
