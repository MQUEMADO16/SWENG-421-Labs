namespace M6Lab
{
    public partial class Form1 : Form
    {
        Graph_Manager graph_manager = Graph_Manager.getGraphManager();
        List<Graph> graphs = new List<Graph>();
        Graph selectedGraph;

        public Form1()
        {
            InitializeComponent();
        }

        private void addVertexClick(object sender, EventArgs e)
        {
            if (selectedGraph != null)
            {
                graph_manager.addVertex(selectedGraph, new Random().Next(panel1.Width), new Random().Next(panel1.Height));
                graphs.Add(selectedGraph);
            }
        }

        private void addEdgeClick(object sender, EventArgs e)
        {
            if (selectedGraph != null)
            {
                try
                {
                    graph_manager.addEdge(selectedGraph);
                    graphs.Add(selectedGraph);
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
            graphs.Add(g);
            graphComboBox.Items.Add(g.ID);
            graphComboBox.SelectedItem = g.ID;
            selectedGraph = g;
        }

        private void copySelectedGraphClick(object sender, EventArgs e)
        {
            if (selectedGraph != null)
            {
                Graph copiedGraph = graph_manager.copyGraph(selectedGraph);
                graphs.Add(copiedGraph);
                graphComboBox.Items.Add(copiedGraph.ID);
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
            selectedGraph = graphs.First(g => g.ID.ToString() == graphComboBox.SelectedItem?.ToString());
        }
    }
}
