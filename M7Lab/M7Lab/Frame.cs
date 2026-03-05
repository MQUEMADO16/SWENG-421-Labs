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
        public Frame() { }

        public void save()
        {
            Console.WriteLine("Saved from frame");
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved from frame");
        }

        public void view()
        {
            Console.WriteLine("Viewed from frame");
        }

        public void edit()
        {
            Console.WriteLine("Editted from frame");
        }

        public void delete()
        {
            ; Console.WriteLine("Deleted from frame");
        }
    }
}
