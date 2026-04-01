using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace M10Lab
{
    internal interface IEmployee
    {
        public string Name { get; }
        public EmployeeRank Rank { get; }
        public IEmployee? Superior { get; set; }
        public List<IEmployee> Subordinates { get; }

        public void addSubordinate(IEmployee subordinate);
        public void seeDanger();
        public void fixIt();
        public string provideInfo();
        public void evacuate();
    }
}
