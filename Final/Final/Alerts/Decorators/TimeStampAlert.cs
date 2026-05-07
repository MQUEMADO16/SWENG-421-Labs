using System;
using Final.Models;

namespace Final.Alerts.Decorators
{
    public class TimeStampAlert : AlertDecorator
    {
        private TradeDataPoint _data;

        public TimeStampAlert(IAlert alert, TradeDataPoint data) : base(alert)
        {
            _data = data;
        }

        public override string sendAlert()
        {
            // FIXED: Changed to FromUnixTimeMilliseconds
            DateTime time = DateTimeOffset.FromUnixTimeMilliseconds(_data.Timestamp).DateTime.ToLocalTime();

            return base.sendAlert() + $" [Time: {time:HH:mm:ss}]";
        }
    }
}