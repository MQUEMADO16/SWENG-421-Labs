using Final.Models;

namespace Final.Core
{
    internal interface ITradeObserver
    {
        void update(TradeDataPoint data);
    }
}