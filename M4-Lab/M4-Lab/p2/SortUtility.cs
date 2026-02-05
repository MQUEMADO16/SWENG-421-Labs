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
            List<T> sortedList = data;

            int n = sortedList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sortedList[j].CompareTo(sortedList[j + 1]) > 0)
                    {
                        T temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                    }
                }
            }

            return sortedList;
        }
    }
}
