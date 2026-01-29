using M4_Lab.p1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p2
{
    public class BubblesortUtility : SortUtility<ProductIF>
    {
        public BubblesortUtility(string sortName) : base(sortName)
        {
        }

        public override List<ProductIF> sort(List<ProductIF> data)
        {   
            if (getName().Equals("bubblesort"))
            {
                List<ProductIF> sortedList = data;

                int n = sortedList.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (sortedList[j].CompareTo(sortedList[j + 1]) > 0)
                        {
                            ProductIF temp = sortedList[j];
                            sortedList[j] = sortedList[j + 1];
                            sortedList[j + 1] = temp;
                        }
                    }
                }

                print(sortedList);
                return sortedList;
            }
            else if (getName().Equals("quicksort"))
            {
                QuicksortUtility qs = new QuicksortUtility();
                List<ProductIF> sortedList = qs.sort(data);
                return sortedList;
            }
            else
            {   
                // return empty if dont find anything
                Console.WriteLine("Could not find sorting algorithm");
                return new List<ProductIF>();
            }
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
