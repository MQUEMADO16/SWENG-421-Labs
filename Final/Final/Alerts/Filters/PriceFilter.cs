using Final.Models;

namespace Final.Alerts.Filters
{
    internal class PriceFilter : IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {
            return data.Price <= low || data.Price >= high;
        }
    }
}