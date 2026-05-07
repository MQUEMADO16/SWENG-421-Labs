using System;

namespace Final.Providers
{
    public class LiveProviderFactory
    {
        public LiveProviderFactory() { }

        public ILiveStockProvider createLiveProvider(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException(nameof(type), "Provider type cannot be null or empty.");
            }

            return type switch
            {
                "Alpaca" => new AlpacaLiveProvider(),
                "Finnhub" => new FinnhubLiveProvider(),
                _ => throw new ArgumentException($"Unknown provider type: {type}", nameof(type))
            };
        }
    }
}