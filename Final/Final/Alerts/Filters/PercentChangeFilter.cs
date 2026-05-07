using Final.Models;

namespace Final.Alerts.Filters
{
    public class PercentChangeFilter : IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {
            return data.PercentChange <= low || data.PercentChange >= high;
        }
    }
}