namespace WinFormsApp1
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
            Application.Run(new Form1());
        }
    }

    public abstract class Shape
    {
        protected Shape() { }

        public virtual void drawColoredShape(Pen pen, Graphics graphics, int x1, int y1, int x2, int y2) { }
    }

    public class Line : Shape
    {
        public Line() { }

        public override void drawColoredShape(Pen pen, Graphics graphics, int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(pen, x1, y1, x2, y2);
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle() { }

        public override void drawColoredShape(Pen pen, Graphics graphics, int x1, int y1, int x2, int y2)
        {
            int x = Math.Min(x1, x2);
            int y = Math.Min(y1, y2);
            
            int width = Math.Abs(x1 - x2);
            int height = Math.Abs(y1 - y2);

            graphics.DrawRectangle(pen, x, y, width, height);
        }
    }

    public class Ellipse : Shape
    {
        public Ellipse() { }

        public override void drawColoredShape(Pen pen, Graphics graphics, int x1, int y1, int x2, int y2)
        {
            int x = Math.Min(x1, x2);
            int y = Math.Min(y1, y2);
            int width = Math.Abs(x1 - x2);
            int height = Math.Abs(y1 - y2);

            graphics.DrawEllipse(pen, x, y, width, height);
        }
    }
}