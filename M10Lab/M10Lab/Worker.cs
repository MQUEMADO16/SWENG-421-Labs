using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace M10Lab
{
    internal class Worker : EmployeeBase
    {
        public Worker(string name, EmployeeRank rank) : base(name, rank) { }

        public override void seeDanger()
        {
            if (superior != null)
            {
                superior.seeDanger();
            }
        }
    }
}
