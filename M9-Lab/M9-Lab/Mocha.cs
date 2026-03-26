using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class Mocha: CoffeeIF
    {
        private double price = 4.00;
        private int creamCount;
        private int vanillaCount;
        private int chocolateCount;
          

        public Mocha(int creamCount, int vanillaCount, int chocolateCount)
        {
            this.creamCount = creamCount;
            this.vanillaCount = vanillaCount;
            this.chocolateCount = chocolateCount;
        }

        public double computePrice()
        {
            return price + (Cream.computePrice() * creamCount) + (Vanilla.computePrice() * vanillaCount) +
                (Chocolate.computePrice() * chocolateCount);
        }
    }
}
