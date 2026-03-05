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

        public LineOfText() { }

        public void save()
        {
            Console.WriteLine("Saved to image");
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved from LineOfText");
        }

        public void view()
        {
            Console.WriteLine("Viewed from LineOfText");
        }

        public void edit()
        {
            Console.WriteLine("Editted from LineOfText");
        }

        public void delete()
        {
;           Console.WriteLine("Deleted from LineOfText");
        }
    }
}
