using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M11Lab
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Calculator calculator = new Calculator();
            Equals eq = new Equals();

            calculator.nextState(1);
            calculator.nextState(2);
            calculator.nextState(new Add());
            calculator.nextState(3);
            calculator.nextState(4);
            calculator.nextState(eq);
            Console.WriteLine(eq.result);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
