using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Final.Core;
using Final.Alerts;
using Final.Models;
using Final.Providers;

namespace Final.Engine
{
    public class StockMonitorEngine
    {
        private MarketDataCache _globalCache;
        private UserAlertService _alertService;
        private LiveProviderFactory _factory;
        private ILiveStockProvider _activeStream;
        private YahooHistoryService _historicalService;

        private readonly HashSet<string> _activeTickers = new HashSet<string>();

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
            _activeStream = _factory.createLiveProvider("Finnhub");

            // Link the data stream to the cache
            _activeStream.DataTarget = _globalCache;
        }

        /// <summary>
        /// Boots the WebSocket connection and subscribes to an initial batch of tickers.
        /// </summary>
        public async Task startLiveFeed(List<string> initialTickers)
        {
            Debug.WriteLine("[ENGINE] Booting Multiplexed Live Feed...");

            // Ensure the socket is connected before subscribing
            await _activeStream.connect();

            // Loop through and subscribe to everything
            foreach (var ticker in initialTickers)
            {
                await SubscribeToTicker(ticker);
            }
        }

        /// <summary>
        /// Safely adds a new ticker to the open WebSocket stream.
        /// Prevents duplicate subscriptions using a HashSet.
        /// </summary>
        public async Task SubscribeToTicker(string ticker)
        {
            // .Add() returns false if the ticker is already in the HashSet
            if (_activeTickers.Add(ticker))
            {
                await _activeStream.subscribe(ticker);
                Debug.WriteLine($"[ENGINE] Subscribed to new stream: {ticker}");
            }
            else
            {
                Debug.WriteLine($"[ENGINE] Ticker {ticker} is already multiplexed. Skipping.");
            }
        }

        public async Task stopSystem()
        {
            if (_activeStream != null)
            {
                Debug.WriteLine("[ENGINE] Shutting down streams...");
                await _activeStream.disconnect();
                _activeTickers.Clear();
            }
        }

        // UI Helper Methods

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

        public int getActiveStreamCount()
        {
            return _activeTickers.Count;
        }
    }
}