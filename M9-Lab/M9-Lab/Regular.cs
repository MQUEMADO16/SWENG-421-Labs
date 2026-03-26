using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class Regular : CoffeeIF
    {
        private double price = 2.00;
        private int creamCount;
        private int vanillaCount;
        private int chocolateCount;


        public Regular(int creamCount, int vanillaCount, int chocolateCount)
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
