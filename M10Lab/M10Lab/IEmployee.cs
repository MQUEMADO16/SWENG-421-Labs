using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace M10Lab
{
    internal interface IEmployee
    {
        public void addSubordinate(IEmployee subordinate);
        public void seeDanger();
        public void fixIt();
        public string provideInfo();
        public void evacuate();
    }
}
