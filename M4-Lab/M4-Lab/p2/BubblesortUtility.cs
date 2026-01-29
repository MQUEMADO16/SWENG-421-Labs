using M4_Lab.p1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace M4_Lab.p2
{
    public class BubblesortUtility : SortUtility<ProductIF>
    {
        public BubblesortUtility(string sortName) : base(sortName)
        {
        }

        public override List<ProductIF> sort(List<ProductIF> data)
        {
        }
    }
}
