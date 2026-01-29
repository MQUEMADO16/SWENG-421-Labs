using M4_Lab.p1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p2
{
    public class SortUtility<T> where T : ProductIF
    {
        private string sortName = "bubblesort";

        public SortUtility(string sortName)
        {
            this.sortName = sortName;
        }

        public string getName() { return sortName; }
        public void setName(string sortName) { this.sortName = sortName; }

        public virtual List<T> sort(List<T> data)
        {
            return new List<T>();   // temp place holder
            // bubble sort implementation
        }
    }
}
