using System;
using System.Windows.Forms;
using Final.Engine;
using Final.UI;

namespace Final
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Boot up the backend infrastructure
            StockMonitorEngine engine = new StockMonitorEngine();
            engine.initializeSystem();

            // 2. Inject the engine into the main form
            Application.Run(new MainShell(engine));
        }
    }
}