using Final.Models;

namespace Final.Alerts.Filters
{
    internal class VolumeFilter : IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {
            return data.Volume <= low || data.Volume >= high;
        }
    }
}