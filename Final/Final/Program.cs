using System;
using System.Windows.Forms;
using Final.Engine;
using Final.UI;

namespace Final
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var engine = new StockMonitorEngine();
            engine.initializeSystem();
            Application.Run(new MainShell(engine));
        }
    }
}