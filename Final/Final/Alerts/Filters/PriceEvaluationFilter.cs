using Final.Models;

namespace Final.Alerts.Filters
{
    internal class PriceEvaluationFilter : IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {
            return data.PE <= low || data.PE >= high;
        }
    }
}