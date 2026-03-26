using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class Vanilla : CondimentIF
    {
        private static double price = 0.50;

        public static double computePrice()
        {
            return price;
        }
    }
}
