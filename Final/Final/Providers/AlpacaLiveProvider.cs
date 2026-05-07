using Final.Core;

namespace Final.Providers
{
    // We had to stop using this due to a paywall.
    internal class AlpacaLiveProvider : ILiveStockProvider
    {
        public MarketDataCache DataTarget { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task connect()
        {
            return Task.CompletedTask;
        }

        public Task disconnect()
        {
            return Task.CompletedTask;
        }

        public Task subscribe(string ticker)
        {
            return Task.CompletedTask;
        }
    }
}