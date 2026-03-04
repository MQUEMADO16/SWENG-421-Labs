using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Character : LineOfTextIF
    {
        private string character;

        public Character(string character)
        {
            this.character = character;
        }

        public void save(string character)
        {
            this.character = character;
            Console.WriteLine("Saved to character");
        }

        public string retrieve()
        {
            Console.WriteLine("Retrieved from character");
            return character;
        }

        public void view()
        {
            Console.Write(character);
        }

        public void edit(string character)
        {
            this.character = character;
            Console.WriteLine("Editted from character");
        }

        public void delete()
        {
            character = "";
;           Console.WriteLine("Deleted from character");
        }
    }
}
