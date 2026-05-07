namespace Final.Models
{
    internal class TradeDataPoint
    {
        // Live Fields (Updated by WebSocket)
        public string Ticker { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public long Timestamp { get; set; }

        // Static/Hybrid Fields (Updated via REST on startup)
        public double PercentChange { get; set; }
        public double PE { get; set; }
        public double MarketCap { get; set; }

        public TradeDataPoint(string ticker)
        {
            Ticker = ticker;
        }
    }
}