using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Column
    {
        private ArrayList content = new ArrayList();

        public Column() { }

        // TODO
        public void save(string image)
        {
        }

        public ArrayList retrieve()
        {
            Console.WriteLine("Retrieved from Column");
            return content;
        }

        // TODO
        public void view()
        {

        }

        // TODO
        public void edit(string image)
        {
        }

        public void delete()
        {
            content.Clear();
;           Console.WriteLine("Deleted from LineOfText");
        }
    }
}
