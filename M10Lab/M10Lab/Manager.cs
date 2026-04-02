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
        public Manager(string name, EmployeeRank rank) : base(name, rank) { }

        public override void seeDanger()
        {
            Console.WriteLine(subordinates[0].provideInfo());
            contactBoss();
        }

        public void contactBoss()
        {
            if(superior != null)
            {
                superior.seeDanger();
            }
            
        }

        public Decision suggestedDecision()
        {
            return new Decision("The city’s environmental department is notified.");
        }
    }
}
