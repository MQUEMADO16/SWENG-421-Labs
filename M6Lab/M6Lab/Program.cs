namespace M6Lab
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SharedGraphState sharedState = new SharedGraphState();

            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MultiFormContext(new Form1(sharedState), new Form1(sharedState)));
        }
    }
}