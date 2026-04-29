using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class PriceFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {
            if (low <= data.Price <= high)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
