using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6Lab
{
    internal class Graph
    {   
        private int ID { get; }
        public ArrayList vertices = new ArrayList();
        public ArrayList edges = new ArrayList();

        public Graph(int ID) {
            this.ID = ID;
        }

        public void display()
        {
            // TODO
        }

        public Graph copy()
        {
            Graph copyGraph = new Graph(ID + 1);
            copyGraph.vertices = new ArrayList();
            copyGraph.edges = new ArrayList();

            foreach(Vertex vertex in vertices)
            {
                copyGraph.vertices.Add(vertex.copy());
            }

            foreach(Edge edge in edges)
            {
                copyGraph.edges.Add(edge.copy());
            }

            return copyGraph;
        }
    }
}
