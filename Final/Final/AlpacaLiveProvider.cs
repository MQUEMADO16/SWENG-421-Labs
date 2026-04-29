using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Alpaca.Markets;

namespace Final
{
    internal class AlpacaLiveProvider
    {
        private readonly IAlpacaDataClient? client;
        private List<string> tickers = new List<string>();

        public AlpacaLiveProvider()
        {
            Env.Load();
            var apiKey = Environment.GetEnvironmentVariable("ALPACA_KEY");
            var secret = Environment.GetEnvironmentVariable("ALPACA_SECRET");

            if (apiKey != null && secret != null)
            {
                var secretKey = new SecretKey(apiKey, secret);
                client = Environments.Paper.GetAlpacaDataClient(secretKey);
            }
        }

        public void connect()
        {



        }

        public void subscribe(string ticker)
        {
            tickers.Add(ticker);
        }

        public void disconnect()
        {

        }
    }
}
