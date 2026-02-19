using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6Lab
{
    internal class Graph_Manager
    {
        private static Graph_Manager grapher = new Graph_Manager();

        private Graph_Manager() { }

        public static Graph_Manager getGraphManager()
        {
            return grapher;
        }

        public void display()
        {
            // TODO
        }

        public Graph createGraph()
        {
            return new Graph();
        }

        public Graph copyGraph(Graph graph)
        {
            return graph.copy();
        }
    }
}
