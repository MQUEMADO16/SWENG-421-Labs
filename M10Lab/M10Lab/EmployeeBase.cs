using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10Lab
{
    internal abstract class EmployeeBase
    {
        protected string name;
        protected EmployeeRank rank;
        protected IEmployee superior;
        protected List<IEmployee> subordinates = new List<IEmployee>();

        public void addSubordinate(IEmployee subordinate)
        {
            subordinates.Add(subordinate);
        }

        public abstract void seeDanger();
        // virtual in UML but maybe should be abstract?

        public void fixIt()
        {
            Console.WriteLine("The person " + name + " is fixing it.");
        }

        public string provideInfo()
        {   
            return "Information from " + subordinates[0].name;
        }

        public void evacuate()
        {
            Console.WriteLine("The person " + name + " has evacuated.");
        }
    }
} 
