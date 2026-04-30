using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Alpaca.Markets;

namespace Final
{
    internal class AlpacaLiveProvider : ILiveStockProvider
    {   
        /*
        Class to provide Alpaca API
        ENV variables:
        ALPACA_KEY
        ALPACA_SECRET
        */

        private IAlpacaDataClient? _client;
        public IAlpacaDataClient? Client => _client;

        public AlpacaLiveProvider()
        {
            Env.Load();
            connect();
        }

        public void connect()
        {
            var apiKey = Environment.GetEnvironmentVariable("ALPACA_KEY");
            var secret = Environment.GetEnvironmentVariable("ALPACA_SECRET");

            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(secret))
                throw new InvalidOperationException("Missing Alpaca credentials.");

            var secretKey = new SecretKey(apiKey, secret);
            _client = Environments.Paper.GetAlpacaDataClient(secretKey);
        }

        public void disconnect()
        {
            _client = null;
        }

        public void subscribe(string ticker)
        {
            /*
            I don't think we should have this in this class.
            The list of tracked tickers should exist elsewhere,
            and this class is only an interface to access data
            unless I'm misunderstanding
            */
        }
    }
}

