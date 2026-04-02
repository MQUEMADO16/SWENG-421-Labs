using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace M10Lab
{
    internal class CEO : EmployeeBase
    {
        public CEO(string name, EmployeeRank rank) : base(name, rank) { }

        public override void seeDanger()
        {
            List<Decision> decisions = new List<Decision>();

            foreach (IEmployee subordinate in subordinates)
            {
                decisions.Add(((Manager)subordinate).suggestedDecision());
            }

            Decision action = grant(decisions);

            if (action != null)
            {
                action.doIt();
            }

            evacuate();
        }

        public Decision grant(List<Decision> decisions)
        {
            return decisions[0];
        }
    }
}
