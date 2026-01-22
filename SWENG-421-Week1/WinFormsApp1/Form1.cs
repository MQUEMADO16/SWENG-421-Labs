using System.Drawing;
using System.Reflection.Metadata;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Shape drawShape;
        private Pen pen;
        private Bitmap canvas;
        private bool isDrawing = false;
        private int curX, curY;
        private int downX, downY;

        public Form1()
        {
            InitializeComponent();
            drawShape = new Line();
            pen = new Pen(new SolidBrush(Color.Black));

            canvas = new Bitmap(Math.Max(1, panel1.Width), Math.Max(1, panel1.Height));
            panel1.BackgroundImage = canvas;

            panel1.Paint += panel1_Paint;
            panel1.MouseMove += panel1_MouseMove;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            downX = e.X;
            downY = e.Y;
            curX = e.X;
            curY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                curX = e.X;
                curY = e.Y;
                panel1.Invalidate();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing)
            {
                drawShape.drawColoredShape(pen, e.Graphics, downX, downY, curX, curY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            using (Graphics g = Graphics.FromImage(canvas))
            {
                drawShape.drawColoredShape(pen, g, downX, downY, e.X, e.Y);
            }
            panel1.Invalidate();
        }

        private void lineButton_MouseUp(object sender, MouseEventArgs e)
        {
            drawShape = new Line();
        }

        private void rectangleButton_MouseUp(Object sender, MouseEventArgs e)
        {
            drawShape = new Rectangle();
        }

        private void ellipseButton_MouseUP(Object sender, MouseEventArgs e)
        {
            drawShape = new Ellipse();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(panel1.BackColor);
            }
            panel1.Invalidate();
        }

        private void updateColor(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int r) && int.TryParse(textBox5.Text, out int g) && int.TryParse(textBox6.Text, out int b))
                pen = new Pen(Color.FromArgb(r, g, b));
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void Form1_Load_1(object sender, EventArgs e) { }
    }
}