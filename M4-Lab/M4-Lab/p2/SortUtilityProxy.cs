using M4_Lab.p1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p2
{
    public class SortUtilityProxy<T> : SortUtility<ProductIF>
    {

        private SortUtility<ProductIF> sortUtility;

        public SortUtilityProxy(string sortName) : base(sortName)
        {
            if (sortName.ToLower() == "bubblesort")
            {
                sortUtility = new BubblesortUtility<ProductIF>(sortName);
            }
            else if (sortName.ToLower() == "quicksort")
            {
                sortUtility = new QuicksortUtility<ProductIF>(sortName);
            }
            else
            {
                throw new ArgumentException("Invalid sort name: " + sortName);
            }
        }

        public override List<ProductIF> sort(List<ProductIF> data)
        {
            return sortUtility.sort(data);
        }

        public void print(List<ProductIF> data)
        {
            if (sortUtility is BubblesortUtility<ProductIF> bubbleSort)
            {
                bubbleSort.print(data);
            }
            else if (sortUtility is QuicksortUtility<ProductIF> quickSort)
            {
                quickSort.print(data);
            }
        }
    }
}
