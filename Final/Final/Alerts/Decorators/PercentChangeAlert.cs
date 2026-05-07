using Final.Models;

namespace Final.Alerts.Decorators
{
    public class PercentChangeAlert : AlertDecorator
    {
        private TradeDataPoint _data;

        public PercentChangeAlert(IAlert alert, TradeDataPoint data) : base(alert)
        {
            _data = data;
        }

        public override string sendAlert()
        {
            // Formatting to 2 decimal places
            return base.sendAlert() + $" [Day Change: {_data.PercentChange:F2}%]";
        }
    }
}