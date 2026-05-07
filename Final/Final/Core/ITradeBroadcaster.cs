using Final.Models;

namespace Final.Core
{
    internal interface ITradeBroadcaster
    {
        void attachObserver(ITradeObserver observer);
        void detachObserver(ITradeObserver observer);
        void notifyObservers(TradeDataPoint data);
    }
}