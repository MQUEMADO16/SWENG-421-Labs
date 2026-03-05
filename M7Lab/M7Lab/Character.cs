using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Character : DocumentElementIF
    {
        private char character;

        public Character(char character)
        {
            this.character = character;
        }

        public void save(char character)
        {
            this.character = character;
            Console.WriteLine("Saved to character");
        }

        public char retrieve()
        {
            Console.WriteLine("Retrieved from character");
            return character;
        }

        public void view()
        {
            Console.Write(character);
        }

        public void edit(char character)
        {
            this.character = character;
            Console.WriteLine("Editted from character");
        }

        public void delete()
        {
            character = '\0';
;           Console.WriteLine("Deleted from character");
        }
    }
}
