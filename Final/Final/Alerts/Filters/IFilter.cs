using Final.Models;

namespace Final.Alerts.Filters
{
    public interface IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data);
    }
}
