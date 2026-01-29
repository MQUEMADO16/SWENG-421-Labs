using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p1
{
    public interface ProductIF : IComparable<ProductIF>
    {

        protected int ID { get; }
        protected string name { get; set; }
        protected double price { get; set; }

        int IComparable<ProductIF>.CompareTo(ProductIF other)
        {
            if (other == null) return 1;
            if (price > other.price)
                return 1;
            else if (price < other.price)
                return -1;
            else
                return 0;
        }
    }
}
