using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Frame : ColumnContentIF, PageContentIF
    {
        public List<FrameContentIF> content = new List<FrameContentIF>();

        public void save()
        {
            Console.WriteLine("Frame structure saved.");
            foreach (var child in content) child.save();
        }

        public void retrieve()
        {
            Console.WriteLine("Frame structure retrieved.");
            foreach (var child in content) child.retrieve();
        }

        public void edit()
        {
            Console.WriteLine("Frame structure modified.");
            foreach (var child in content) child.edit();
        }

        public void delete()
        {
            Console.WriteLine("Frame structure destroyed.");
            foreach (var child in content) child.delete();
        }

        public void view()
        {
            foreach (var child in content) child.view();
        }
    }
}
