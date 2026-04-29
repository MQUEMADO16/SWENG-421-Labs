using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal interface ILiveStockProvider
    {
        public void connect();
        public void disconnect();
        public void subscribe(string ticker);
    }
}
