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
            ILiveStockProvider provider = factory.createLiveProvider("Yahoo");
            var price = await provider.GetPriceAsync("AAPL");
            Console.WriteLine(price);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}