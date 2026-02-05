using M4_Lab.p1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p2
{
    public class QuicksortUtility<T> : SortUtility<ProductIF>
    {
        public QuicksortUtility(string sortName) : base(sortName)
        {
        }

        public override List<ProductIF> sort(List<ProductIF> data)
        {   

            data.Sort();    // Using built-in sort method which implements quicksort
            print(data);
            return data;
        }

        public void print(List<ProductIF> data)
        {
            Console.WriteLine("Quick sort results: ");

            foreach (ProductIF product in data)
            {
                Console.WriteLine("Price: " + product.price + " Name: " + product.name + " ID: " + product.ID);
            }
        }
    }
}
