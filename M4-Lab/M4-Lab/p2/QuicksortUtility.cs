using M4_Lab.p1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p2
{
    public class QuicksortUtility
    {

        public List<ProductIF> sort(List<ProductIF> data)
        {   

            data.Sort();
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
