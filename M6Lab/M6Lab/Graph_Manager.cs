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

        public Graph createGraph()
        {
            return new Graph();
        }

        public void addVertex(Graph graph, int x, int y)
        {
            Vertex vertex = new Vertex();
            vertex.vertex_ID = new Guid();
            vertex.x_coordinate = x;
            vertex.y_coordinate = y;
            graph.vertices.Add(vertex);
        }

        public void addEdge(Graph graph)
        {
            if (graph.vertices.Count < 2)
            {
                throw new InvalidOperationException("At least two vertices are required to add an edge.");
            }

            Edge edge = new Edge();
            edge.edge_ID = new Guid();

            // Randomly choose two different vertices from the graph to connect with the edge
            int to_vertex_index = new Random().Next(graph.vertices.Count);
            int from_vertex_index = to_vertex_index > 0 ? to_vertex_index - 1 : to_vertex_index + 1;

            edge.from_vertex = graph.vertices[from_vertex_index];
            edge.to_vertex = graph.vertices[to_vertex_index];

            graph.edges.Add(edge);
        }

        public void modifyVertex(Vertex vertex, int x_coordinate, int y_coordinate)
        {
            vertex.x_coordinate = x_coordinate;
            vertex.y_coordinate = y_coordinate;
        }

        public void modifyEdge(Edge edge, Vertex from_vertex, Vertex to_vertex)
        {
            edge.from_vertex = from_vertex;
            edge.to_vertex = to_vertex;
        }

        public Graph copyGraph(Graph graph)
        {
            return graph.copy();
        }
    }
}
