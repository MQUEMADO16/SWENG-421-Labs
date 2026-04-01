using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M10Lab
{
    internal abstract class EmployeeBase : IEmployee
    {
        protected string name;
        protected EmployeeRank rank;
        protected IEmployee? superior;
        protected List<IEmployee> subordinates = new List<IEmployee>();

        public string Name { get { return name; } }
        public EmployeeRank Rank { get { return rank; } }
        public IEmployee? Superior { get { return superior; } set { superior = value; } }
        public List<IEmployee> Subordinates { get { return subordinates; } }

        protected EmployeeBase(string name, EmployeeRank rank)
        {
            this.name = name;
            this.rank = rank;
            superior = null;
            subordinates = new List<IEmployee>();
        }

        public void addSubordinate(IEmployee subordinate)
        {
            if (rank <= subordinate.Rank)
            {
                throw new InvalidOperationException(
                    $"{name} ({rank}) cannot supervise {subordinate.Name} ({subordinate.Rank}).");
            }

            subordinate.Superior = this;

            subordinates.Add(subordinate);
        }

        public abstract void seeDanger();

        public void fixIt()
        {
            Console.WriteLine("The person " + name + " is fixing it.");
        }

        public string provideInfo()
        {   
            return "Information from " + subordinates[0].Name;
        }

        public void evacuate()
        {
            foreach (var sub in subordinates)   // no null check needed. subordinates list will always be instantiated but may be empty
            {
                sub.evacuate();
            }

            Console.WriteLine("The person " + name + " has evacuated.");
        }
    }
} 
