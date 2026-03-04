using System;
using System.Linq;
using System.Windows.Forms;

namespace M6Lab
{
    internal partial class Form1 : Form
    {
        Graph_Manager graph_manager = Graph_Manager.getGraphManager();
        SharedGraphState sharedState;
        Graph selectedGraph;

        public Form1(SharedGraphState state)
        {
            InitializeComponent();
            sharedState = state;

            sharedState.DataUpdated += SharedState_DataUpdated;
        }

        private void SharedState_DataUpdated(object sender, EventArgs e)
        {
            var currentSelection = graphComboBox.SelectedItem;

            graphComboBox.Items.Clear();
            foreach (var g in sharedState.Graphs)
            {
                graphComboBox.Items.Add(g.ID);
            }

            if (currentSelection != null && graphComboBox.Items.Contains(currentSelection))
            {
                graphComboBox.SelectedItem = currentSelection;
            }

            panel1.Refresh();
            if (selectedGraph != null)
            {
                selectedGraph.display(panel1);
            }
        }

        private void addVertexClick(object sender, EventArgs e)
        {
            if (selectedGraph != null)
            {
                graph_manager.addVertex(selectedGraph, Random.Shared.Next(panel1.Width), Random.Shared.Next(panel1.Height));

                sharedState.NotifyDataUpdated();
            }
        }

        private void addEdgeClick(object sender, EventArgs e)
        {
            if (selectedGraph != null)
            {
                try
                {
                    graph_manager.addEdge(selectedGraph);

                    sharedState.NotifyDataUpdated();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void createGraphClick(object sender, EventArgs e)
        {
            Graph g = graph_manager.createGraph();

            sharedState.Graphs.Add(g);
            selectedGraph = g;

            sharedState.NotifyDataUpdated();

            graphComboBox.SelectedItem = g.ID;
        }

        private void copySelectedGraphClick(object sender, EventArgs e)
        {
            if (selectedGraph != null)
            {
                Graph copiedGraph = graph_manager.copyGraph(selectedGraph);

                sharedState.Graphs.Add(copiedGraph);

                sharedState.NotifyDataUpdated();
            }
        }

        private void displayButtonClick(object sender, EventArgs e)
        {
            if (selectedGraph != null)
            {
                panel1.Refresh();
                selectedGraph.display(panel1);
            }
        }

        private void graphComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (graphComboBox.SelectedItem != null)
            {
                selectedGraph = sharedState.Graphs.First(g => g.ID.ToString() == graphComboBox.SelectedItem.ToString());

                panel1.Refresh();
                selectedGraph.display(panel1);
            }
        }

        private void modifyVertexClick(object sender, EventArgs e)
        {
            if (selectedGraph != null && selectedGraph.vertices.Count > 0)
            {
                Vertex vertex = selectedGraph.vertices[Random.Shared.Next(selectedGraph.vertices.Count)];
                if (vertex != null)
                {
                    vertex.x_coordinate = Random.Shared.Next(panel1.Width);
                    vertex.y_coordinate = Random.Shared.Next(panel1.Height);

                    sharedState.NotifyDataUpdated();
                }
            }
        }

        private void modifyEdgeClick(object sender, EventArgs e)
        {
            if (selectedGraph != null && selectedGraph.edges.Count > 0)
            {
                Edge edge = selectedGraph.edges[Random.Shared.Next(selectedGraph.edges.Count)];
                if (edge != null)
                {
                    int from_vertex_index = Random.Shared.Next(selectedGraph.vertices.Count);
                    int to_vertex_index;

                    if (from_vertex_index == 0 && selectedGraph.vertices.Count > 1)
                        to_vertex_index = from_vertex_index + 1;
                    else
                        to_vertex_index = from_vertex_index - 1;

                    edge.from_vertex = selectedGraph.vertices[from_vertex_index];
                    edge.to_vertex = selectedGraph.vertices[to_vertex_index];

                    sharedState.NotifyDataUpdated();
                }
            }
        }
    }
}