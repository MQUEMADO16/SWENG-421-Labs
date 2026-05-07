using Final.Models;

namespace Final.Alerts.Filters
{
    public class PriceEvaluationFilter : IFilter
    {
        public bool getData(double low, double high, TradeDataPoint data)
        {
            return data.PE <= low || data.PE >= high;
        }
    }
}