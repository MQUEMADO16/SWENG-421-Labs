using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Column : PageContentIF, FrameContentIF
    {
        public List<ColumnContentIF> content = new List<ColumnContentIF>();

        public void save()
        {
            Console.WriteLine("Saved column.");
            foreach (var child in content) child.save();
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved column.");
            foreach (var child in content) child.retrieve();
        }

        public void edit()
        {
            Console.WriteLine("Edited column.");
            foreach (var child in content) child.edit();
        }

        public void delete()
        {
            Console.WriteLine("Deleted column.");
            foreach (var child in content) child.delete();
        }

        public void view()
        {
            foreach (var child in content) child.view();
        }
    }
}
