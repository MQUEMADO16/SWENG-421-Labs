using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6Lab
{
    internal class Vertex
    {
        private Guid _vertex_ID;
        private int _x_coordinate;
        private int _y_coordinate;

        public Guid vertex_ID { get { return _vertex_ID; } set { _vertex_ID = value; } }
        public int x_coordinate { get { return _x_coordinate; } set { _x_coordinate = value; } }
        public int y_coordinate { get { return _y_coordinate; } set { _y_coordinate = value; } }
            
        public Vertex() { }

        public void drawing(Panel panel)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                SolidBrush b = new SolidBrush(Color.Black);
                Rectangle r = new Rectangle(x_coordinate-5, y_coordinate-5, 10, 10);
                g.FillEllipse(b, r);
            }
        }

        public Vertex copy()
        {
            Vertex copyVertex = new Vertex();
            copyVertex.vertex_ID = vertex_ID;
            copyVertex.x_coordinate = x_coordinate;
            copyVertex.y_coordinate = y_coordinate;

            return copyVertex;
        }
    }
}
