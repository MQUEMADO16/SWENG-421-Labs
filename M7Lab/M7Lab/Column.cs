using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Column : PageContentIF
    {
        public List<ColumnContentIF> content = new List<ColumnContentIF>();

        public Column() { }

        public void save()
        {
            Console.WriteLine("Saved from column");
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved from column");
        }
        public void view()
        {
            Console.WriteLine("Viewed from column");
        }

        public void edit()
        {
            Console.WriteLine("Editted from column");
        }

        public void delete()
        {
;           Console.WriteLine("Deleted from column");
        }
    }
}
