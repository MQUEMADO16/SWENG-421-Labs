using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class PercentChangeAlert
    {
        private TradeDataPoint point1;
        private TradeDataPoint point2;
        private double percent;

        public PercentChangeAlert(TradeDataPoint point1, TradeDataPoint point2, double percent)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.percent = percent;
        }

        public string sendAlert()
        {
            // percent change point 1 price point 2 price
            return "Trade has reached percent change " + percent;
        }
    }
}
