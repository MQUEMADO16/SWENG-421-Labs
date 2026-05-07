using Final.Alerts.Filters;

namespace Final.Models
{
    public class AlertRule
    {
        public string TargetTicker { get; set; }
        public double LowThreshold { get; set; }
        public double HighThreshold { get; set; }
        public IFilter ActiveFilter { get; set; }

        // Decorator Flags for the UI
        public bool IncludeTimestamp { get; set; }
        public bool IncludePercentChange { get; set; }

        public AlertRule(string ticker, double low, double high, IFilter filter)
        {
            TargetTicker = ticker;
            LowThreshold = low;
            HighThreshold = high;
            ActiveFilter = filter;
        }

        public bool IsTriggered(TradeDataPoint data)
        {
            return ActiveFilter.getData(LowThreshold, HighThreshold, data);
        }
    }
}