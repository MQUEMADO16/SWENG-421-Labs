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
    }
}
