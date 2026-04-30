using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpaca.Markets;

namespace Final
{
    internal interface ILiveStockProvider
    {
        IAlpacaDataClient Client { get; }

        public void connect();
        public void disconnect();
        public void subscribe(string ticker);
    }
}
