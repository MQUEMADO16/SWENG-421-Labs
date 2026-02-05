using M4_Lab.p1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p2
{
    public class BubblesortUtility<T> : SortUtility<ProductIF>
    {
        public BubblesortUtility(string sortName) : base(sortName)
        {
        }

        public override List<ProductIF> sort(List<ProductIF> data)
        {
            List<ProductIF> sortedData = base.sort(data);
            print(sortedData);
            return sortedData;
        }

        public void print(List<ProductIF> data)
        {
            Console.WriteLine("Bubble sort results: ");

            foreach (ProductIF product in data)
            {
                Console.WriteLine("ID: " + product.ID + " Name: " + product.name + " Price: " + product.price);
            }
        }
    }
}
