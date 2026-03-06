using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Character : LineOfTextContentIF
    {
        private char characterValue;

        public Character(char c)
        {
            this.characterValue = c;
        }

        public void save()
        {
            Console.WriteLine($"Char '{characterValue}' saved.");
        }

        public void retrieve()
        {
            Console.WriteLine($"Char '{characterValue}' retrieved.");
        }

        public void edit()
        {
            Console.WriteLine($"Char '{characterValue}' changed.");
        }

        public void delete()
        {
            Console.WriteLine($"Char '{characterValue}' deleted.");
        }

        public void view()
        {
            Console.Write(characterValue);
        }
    }
}
