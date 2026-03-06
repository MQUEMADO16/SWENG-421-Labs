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

        public void save()
        {
            Console.WriteLine("A page has been saved.");
            foreach (var child in content) child.save();
        }

        public void retrieve()
        {
            Console.WriteLine("A page has been retrieved.");
            foreach (var child in content) child.retrieve();
        }

        public void edit()
        {
            Console.WriteLine("A page has been updated.");
            foreach (var child in content) child.edit();
        }

        public void delete()
        {
            Console.WriteLine("A page has been removed.");
            foreach (var child in content) child.delete();
        }

        public void view()
        {
            foreach (var child in content) child.view();
        }
    }
}
