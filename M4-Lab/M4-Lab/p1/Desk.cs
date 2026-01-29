using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace M4_Lab.p1
{
    public class Desk : ProductIF
    {
        // Fields
        private readonly int _ID;
        private string _name = "Desk";
        private double _price;

        public Desk(int id, double price, string name)
        {
            _ID = id;
            _price = price;
            _name = name;
        }

        // Properties
        public int ID { get => _ID; }
        public string name { get => _name; set => _name = value; }
        public double price { get => _price; set => _price = value; }
    }
}
