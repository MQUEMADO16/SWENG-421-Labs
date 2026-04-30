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
        public string Ticker { get; set; }
        public double Price { get; set; }
        public long Volume { get; set; }
        public Instant Timestamp { get; set; }

        public TradeDataPoint() { }
    }
}
