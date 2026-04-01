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
        public CEO(string name, EmployeeRank rank)
        {
            this.name = name;
            this.rank = rank;
        }

        public override void seeDanger()
        {
            foreach(IEmployee subordinate in subordinates)
            {
                // subordinate.suggestedDecision();
            }
        }
    }
}
