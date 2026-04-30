using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class LiveProviderFactory
    {
        public LiveProviderFactory() { }

        public ILiveStockProvider createLiveProvider(string type)
        {
            if (type == null) throw new ArgumentNullException("type");

            if (type == "Alpaca")
            {
                return new AlpacaLiveProvider();
            } else if(type == "Yahoo")
            {
                return new YahooLiveProvider();
            }
            // else if Finnhub, etc

            throw new ArgumentException("Unknown provider type", nameof(type));
        }
    }
}
