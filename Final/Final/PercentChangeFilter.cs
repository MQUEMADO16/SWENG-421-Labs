using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class PercentChangeFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {   
            // TODO some kind of historic change in TradeDataPoint?
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
