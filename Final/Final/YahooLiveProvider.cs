using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using YahooFinanceApi;

namespace Final
{
    internal class YahooLiveProvider : ILiveStockProvider
    {   
        // Yahoo finance exists as a static class for the import. No connection necessary
        public YahooLiveProvider()
        {
        }

        public void connect()
        {
        }

        public void disconnect()
        {
        }

        public async Task<double?> GetPriceAsync(string ticker)
        {
            Console.WriteLine("Hello");
            var call = await Yahoo
                .Symbols(ticker)
                .Fields(Field.RegularMarketPrice)
                .QueryAsync();

            if (call != null) { 
                var price = call[ticker][Field.RegularMarketPrice];
                double? result = Convert.ToDouble(price);
                return result;
            }

            return null;
        }

        public void subscribe(string ticker)
        {
        }
    }
}

