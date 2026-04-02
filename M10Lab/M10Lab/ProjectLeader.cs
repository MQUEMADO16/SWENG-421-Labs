using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace M10Lab
{
    internal class ProjectLeader : EmployeeBase
    {
        public ProjectLeader(string name, EmployeeRank rank) : base(name, rank) { }

        public override void seeDanger()
        {
            foreach (IEmployee subordinate in subordinates)
            {
                subordinate.fixIt();
            }

            if (superior != null)
            {
                superior.seeDanger();
            }
        }
    }
}
