using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M8Lab
{
    internal class TV
    {
        private int MSRP;
        private string Type;

        public TV(int MSRP, string Type) {
            this.MSRP = MSRP;
            this.Type = Type;
        }

        public TV replenish(string type, int budget)
        {   
            // placeholder
            return new SmartTV();
        }

        public string getType()
        {
            return Type;
        }

        public int getPrice()
        {
            return MSRP;
        }

        public string getInfo()
        {
            return "Type: " + getType() + " | Price: " + getPrice();
        }

        protected class SmartTV : TV
        {
        }
        protected class UltraTV : TV
        {
        }
    }
}
