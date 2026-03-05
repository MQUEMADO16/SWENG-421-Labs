using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Character : LineOfTextContentIF
    {
        public char character;

        public Character() {}

        public void save()
        {
            Console.WriteLine("Saved to character");
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved from character");
        }

        public void view()
        {
            Console.WriteLine("Viewed from character");
        }

        public void edit()
        {
            Console.WriteLine("Editted from character");
        }

        public void delete()
        {
            Console.WriteLine("Deleted from character");
        }
    }
}
