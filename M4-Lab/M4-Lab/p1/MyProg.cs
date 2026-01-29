using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M4_Lab.p2;

namespace M4_Lab.p1
{
    public class MyProg
    {
        public static void Main(string[] args)
        {
            MyProg grabber = new MyProg();
            List<ProductIF> products1 = grabber.getProducts();
            List<ProductIF> products2 = grabber.getProducts();
            
            Company xyz = new Company();
            xyz.sortUtility = new SortUtility<ProductIF>("bubblesort");
            xyz.sortUtility.sort(products1);
            xyz.sortUtility.setName("quicksort");
            xyz.sortUtility.sort(products2);
        }

        public List<ProductIF> getProducts()
        {   
            List<ProductIF> products = [
                new Desk(1, 20.30, "Writing Desk"),
                new Desk(2, 15.25, "Corner Desk"),
                new Desk(3, 25.13, "Lap Desk"),
                new Desk(4, 15.85, "Standing Desk"),
                new Desk(5, 22.56, "Floating Desk"),
            ];  

            return products;
        }
    }
}
