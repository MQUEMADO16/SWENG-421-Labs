using System.Threading.Tasks;
using Alpaca.Markets;

namespace Final
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            LiveProviderFactory factory = new LiveProviderFactory();
            ILiveStockProvider AlpacaProvider = factory.createLiveProvider("Alpaca");
            
            var client = AlpacaProvider.Client;
            var request = new LatestMarketDataRequest("AAPL");
            var quote = await client.GetLatestQuoteAsync(request);
            var price = quote.AskPrice;
            Console.WriteLine(price);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}