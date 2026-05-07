using Final.Models;

namespace Final.Alerts.Decorators
{
    public class PriceAlert : IAlert
    {
        private TradeDataPoint _data;
        private double _low;
        private double _high;

        public PriceAlert(TradeDataPoint data, double low, double high)
        {
            _data = data;
            _low = low;
            _high = high;
        }

        public string sendAlert()
        {
            // The base message
            return $"ALERT: {_data.Ticker} triggered! Live Value: {_data.Price} (Range: {_low} to {_high})";
        }
    }
}