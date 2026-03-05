using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Page : NovelContentIF
    {
        public List<PageContentIF> content = new List<PageContentIF>();
        public Page() { }

        public void save()
        {
            Console.WriteLine("Saved from page");
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved from page");
        }

        public void view()
        {
            Console.WriteLine("Viewed from page");
        }

        public void edit()
        {
            Console.WriteLine("Editted from page");
        }

        public void delete()
        {
            Console.WriteLine("Deleted from page");
        }
    }
}
