using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace Final
{
    internal class TradeDataPoint
    {
        private string ticker { get; set; }
        private double currentPrice { get; set; }
        private long volume { get; set; }
        private Instant timestamp { get; set; }

        public TradeDataPoint()
        {

        }
    }
}
