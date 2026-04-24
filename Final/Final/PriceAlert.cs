using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class PriceAlert : Alert
    {
        private TradeDataPoint data;
        private double priceThreshold;

        public PriceAlert(TradeDataPoint data, double priceThreshold)
        {
            this.data = data;
            this.priceThreshold = priceThreshold;
        }

        public string sendAlert()
        {
            // if tradedatapoint.price > priceThreshold
            return "Price met threshold";
        }
    }
}
