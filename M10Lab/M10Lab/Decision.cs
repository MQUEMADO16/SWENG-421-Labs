using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10Lab
{
    internal class Decision
    {
        private string decision;

        public Decision(string decision)
        {
            this.decision = decision;
        }

        public void doIt()
        {
            Console.WriteLine(decision);
        }
    }
}
