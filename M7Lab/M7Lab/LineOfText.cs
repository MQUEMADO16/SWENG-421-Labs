using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class LineOfText : ColumnContentIF
    {
        public List<LineOfTextContentIF> content = new List<LineOfTextContentIF>();

        public void save()
        {
            Console.WriteLine("Text line stored.");
            foreach (var child in content) child.save();
        }

        public void retrieve()
        {
            Console.WriteLine("Text line fetched.");
            foreach (var child in content) child.retrieve();
        }

        public void edit()
        {
            Console.WriteLine("Text line altered.");
            foreach (var child in content) child.edit();
        }

        public void delete()
        {
            Console.WriteLine("Text line erased.");
            foreach (var child in content) child.delete();
        }

        public void view()
        {
            foreach (var child in content) child.view();
        }
    }
}
