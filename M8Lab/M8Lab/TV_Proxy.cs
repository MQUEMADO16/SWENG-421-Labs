using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M8Lab
{
    internal class TV_Proxy : TV, TV_IF
    {
        public TV tv;
        private TV_IF tvif;

        public TV_Proxy(TV tv, TV_IF tvif)
        {
            this.tv = tv;
            this.tvif = tvif;
        }

        public new TV_IF replenish(string type, int budget)
        {
            return tvif.replenish(type, budget);
        }
    }
}
