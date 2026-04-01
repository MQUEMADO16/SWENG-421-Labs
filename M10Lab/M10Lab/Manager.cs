using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace M10Lab
{
    internal class Manager : EmployeeBase
    {
        public Manager(string name, EmployeeRank rank)
        {
            this.name = name;
            this.rank = rank;
        }

        public override void seeDanger()
        {
            Console.WriteLine(subordinates[0].provideInfo());
            contactBoss();
        }

        public void contactBoss()
        {
            Superior.seeDanger();
        }

        public Decision suggestedDecision()
        {
            return new Decision("The city’s environmental department is notified.");
        }
    }
}
