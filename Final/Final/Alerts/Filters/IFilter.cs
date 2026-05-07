using Final.Models;

namespace Final.Alerts.Filters
{
    internal interface IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data);
    }
}
