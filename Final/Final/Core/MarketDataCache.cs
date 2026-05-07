using System.Collections.Generic;
using Final.Models;

namespace Final.Core
{
    public class MarketDataCache : ITradeBroadcaster
    {
        // State
        private readonly Dictionary<string, TradeDataPoint> _liveCache;
        private readonly List<ITradeObserver> _observers;

        // Concurrency Lock
        private readonly ReadWriteLock _lockManager;

        public MarketDataCache()
        {
            _liveCache = new Dictionary<string, TradeDataPoint>();
            _observers = new List<ITradeObserver>();
            _lockManager = new ReadWriteLock();
        }

        // WRITER PATH
        public void updateLiveDataPoint(TradeDataPoint dataPoint)
        {
            _lockManager.lockWrite();
            try
            {
                _liveCache[dataPoint.Ticker] = dataPoint;
            }
            finally
            {
                _lockManager.unlockWrite();
            }

            notifyObservers(dataPoint);
        }

        // READER PATH
        public TradeDataPoint? getLiveDataPoint(string ticker)
        {
            _lockManager.lockRead();
            try
            {
                if (_liveCache.TryGetValue(ticker, out TradeDataPoint? dataPoint))
                {
                    return dataPoint;
                }
                return null;
            }
            finally
            {
                _lockManager.unlockRead();
            }
        }

        // OBSERVER PATTERN METHODS
        public void attachObserver(ITradeObserver observer)
        {
            _lockManager.lockWrite();
            try { _observers.Add(observer); }
            finally { _lockManager.unlockWrite(); }
        }

        public void detachObserver(ITradeObserver observer)
        {
            _lockManager.lockWrite();
            try { _observers.Remove(observer); }
            finally { _lockManager.unlockWrite(); }
        }

        public void notifyObservers(TradeDataPoint dataPoint)
        {
            List<ITradeObserver> observersCopy;

            _lockManager.lockRead();
            try
            {
                observersCopy = new List<ITradeObserver>(_observers);
            }
            finally
            {
                _lockManager.unlockRead();
            }

            foreach (var observer in observersCopy)
            {
                observer.update(dataPoint);
            }
        }
    }
}