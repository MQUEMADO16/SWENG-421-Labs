using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee ceo = new CEO("Steve", EmployeeRank.Ceo);
            IEmployee manager1 = new Manager("Bob", EmployeeRank.Manager);
            IEmployee manager2 = new Manager("Rachel", EmployeeRank.Manager);
            manager1.Superior = ceo;
            manager2.Superior = ceo;
            ceo.addSubordinate(manager1);
            ceo.addSubordinate(manager2);

            IEmployee projectleader1 = new ProjectLeader("Chuck", EmployeeRank.ProjectLeader);
            IEmployee projectleader2 = new ProjectLeader("Denise", EmployeeRank.ProjectLeader);
            projectleader1.Superior = manager2;
            projectleader1.Superior = manager2;
            manager2.addSubordinate(projectleader1);
            manager2.addSubordinate(projectleader2);

            IEmployee supervisor1 = new Supervisor("Jack", EmployeeRank.Supervisor);
            IEmployee supervisor2 = new Supervisor("Jeff", EmployeeRank.Supervisor);
            supervisor1.Superior = manager1;
            supervisor2.Superior = manager1;
            manager1.addSubordinate(supervisor1);
            manager1.addSubordinate(supervisor2);

            IEmployee worker1 = new Worker("John", EmployeeRank.Worker);
            IEmployee worker2 = new Worker("Mary", EmployeeRank.Worker);
            IEmployee worker3 = new Worker("Jane", EmployeeRank.Worker);
            worker1.Superior = supervisor1;
            worker2.Superior = supervisor1;
            worker3.Superior = supervisor1;
            supervisor1.addSubordinate(worker1);
            supervisor1.addSubordinate(worker2);
            supervisor1.addSubordinate(worker3);

            worker1.seeDanger();
        }
    }
}
