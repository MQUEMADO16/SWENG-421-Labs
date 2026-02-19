using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6Lab
{
    internal class Vertex
    {
        private int vertex_ID { get; set; }
        private int x_coordinate { get; set; }
        private int y_coordinate { get; set; }
            
        public Vertex() { }

        public void drawing()
        {
            // TODO
        }

        public Vertex copy()
        {
            Vertex copyVertex = new Vertex();
            copyVertex.vertex_ID = vertex_ID + 1;
            copyVertex.x_coordinate = x_coordinate;
            copyVertex.y_coordinate = y_coordinate;

            return copyVertex;
        }
    }
}
