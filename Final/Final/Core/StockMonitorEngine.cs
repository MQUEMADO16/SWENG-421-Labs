using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Final.Core;
using Final.Alerts;
using Final.Models;
using Final.Providers;

namespace Final.Engine
{
    public class StockMonitorEngine
    {
        // Fields exactly matching your UML (using C# _camelCase for private variables)
        private MarketDataCache _globalCache;
        private UserAlertService _alertService;
        private LiveProviderFactory _factory;
        private ILiveStockProvider _activeStream;
        private YahooHistoryService _historicalService;

        public StockMonitorEngine()
        {
        }

        public void initializeSystem()
        {
            // Stand up the infrastructure
            _globalCache = new MarketDataCache();
            _alertService = new UserAlertService(_globalCache);
            _factory = new LiveProviderFactory();
            _historicalService = new YahooHistoryService();

            // Use the Factory to get the provider
            // Note that it could be set up to accept user input to select a new provider, leveraging Factory Method
            _activeStream = _factory.createLiveProvider("Finnhub");

            // Link the data stream to the cache
            _activeStream.DataTarget = _globalCache;
        }

        public async Task startLiveFeed(string ticker)
        {
            // Ensure the socket is connected before subscribing
            await _activeStream.connect();
            await _activeStream.subscribe(ticker);
        }

        public async Task stopSystem()
        {
            if (_activeStream != null)
            {
                await _activeStream.disconnect();
            }
        }

        // UI Helper Methodsm

        public UserAlertService getAlertService()
        {
            return _alertService;
        }

        public async Task<List<TradeDataPoint>> fetchInitialChartData(string ticker)
        {
            DateTime end = DateTime.Now;
            DateTime start = end.AddDays(-30);

            return await _historicalService.getHistoricalData(ticker, start, end);
        }
    }
}