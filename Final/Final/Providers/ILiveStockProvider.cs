using Final.Core;

namespace Final.Providers
{
    internal interface ILiveStockProvider
    {
        MarketDataCache DataTarget { get; set; }
        Task connect();
        Task disconnect();
        Task subscribe(string ticker);
    }
}