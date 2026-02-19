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
        private int edge_ID { get; set; }
        private Vertex from_vertex { get; set; }
        private Vertex to_vertex { get; set; }

        public Edge() { 
            from_vertex = new Vertex();
            to_vertex = new Vertex();
        }

        public void drawing()
        {
            // TODO
        }

        public Edge copy()
        {
            Edge copyEdge = new Edge();
            copyEdge.edge_ID = edge_ID + 1;
            copyEdge.from_vertex = from_vertex.copy();
            copyEdge.to_vertex = to_vertex.copy();

            return copyEdge;
        }
    }
}
