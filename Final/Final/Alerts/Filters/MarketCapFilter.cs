using Final.Models;

namespace Final.Alerts.Filters
{
    internal class MarketCapFilter : IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {
            return data.MarketCap <= low || data.MarketCap >= high;
        }
    }
}