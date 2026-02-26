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
        public Guid ID { get; }
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();

        public Graph() {
            ID = Guid.NewGuid();
        }

        public void display(Panel panel)
        {
            foreach(Vertex vertex in vertices)
            {
                vertex.drawing(panel);
            }

            foreach(Edge edge in edges)
            {
                edge.drawing(panel);
            }
        }

        public Graph copy()
        {
            Graph copyGraph = new Graph();
            copyGraph.vertices = new List<Vertex>();
            copyGraph.edges = new List<Edge>();

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
