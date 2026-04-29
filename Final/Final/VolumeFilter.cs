using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class PEFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {   
            // TODO need some kind of data point in TradeDataPoint for PE
            if (low <= data.Volume <= high)
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
