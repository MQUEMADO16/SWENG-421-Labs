// Class to hold data shared between both form windows
namespace M6Lab
{
    internal class SharedGraphState
    {
        // The shared list of graphs
        public List<Graph> Graphs { get; set; } = new List<Graph>();

        // An event to notify all listening forms that the data changed
        public event EventHandler DataUpdated;

        // Method to trigger the update event
        public void NotifyDataUpdated()
        {
            DataUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}