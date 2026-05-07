using Final.Core;

namespace Final.Providers
{
    public interface ILiveStockProvider
    {
        MarketDataCache DataTarget { get; set; }
        Task connect();
        Task disconnect();
        Task subscribe(string ticker);
        long getCurrentLatencyMs();
    }
}