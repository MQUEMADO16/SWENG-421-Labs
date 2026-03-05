using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Novel
    {
        public List<NovelContentIF> content = new List<NovelContentIF>();
        public Novel() { }

        public void save()
        {
            Console.WriteLine("Saved from novel");
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved from novel");
        }

        public void view()
        {
            Console.WriteLine("Viewed from novel");
        }

        public void edit()
        {
            Console.WriteLine("Editted from novel");
        }

        public void delete()
        {
            Console.WriteLine("Deleted from novel");
        }
    }
}
