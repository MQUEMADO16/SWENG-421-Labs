using Final.Models;

namespace Final.Core
{
    public interface ITradeObserver
    {
        void update(TradeDataPoint data);
    }
}