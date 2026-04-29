using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal interface FilterIF
    {
        public bool getData(double low, double high, TradeDataPoint data);
    }
}
