using System;
using System.Collections.Generic;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6Lab
{
    internal class Edge
    {
        private Guid _edge_ID;
        private Vertex _from_vertex;
        private Vertex _to_vertex;

        public Guid edge_ID { get { return _edge_ID; } set { _edge_ID = value; } }
        public Vertex from_vertex { get { return _from_vertex; } set { _from_vertex = value; } }
        public Vertex to_vertex { get { return _to_vertex; } set { _to_vertex = value; } }

        public Edge() { 
            from_vertex = new Vertex();
            to_vertex = new Vertex();
        }

        public void drawing(Panel panel)
        {
            using (Graphics g = panel.CreateGraphics())
            {
                g.DrawLine(new Pen(new SolidBrush(Color.Black)), from_vertex.x_coordinate, from_vertex.y_coordinate, to_vertex.x_coordinate, to_vertex.y_coordinate);
            }
        }

        public Edge copy()
        {
            Edge copyEdge = new Edge();
            copyEdge.edge_ID = edge_ID;
            copyEdge.from_vertex = from_vertex.copy();
            copyEdge.to_vertex = to_vertex.copy();

            return copyEdge;
        }
    }
}
