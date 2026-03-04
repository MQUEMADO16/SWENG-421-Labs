using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class LineOfText
    {
        private ArrayList content = new ArrayList();

        public LineOfText() { }

        public void save(LineOfTextIF obj)
        {
            content.Add(obj);
            Console.WriteLine("Saved to image");
        }

        public ArrayList retrieve()
        {
            Console.WriteLine("Retrieved from LineOfText");
            return content;
        }

        public void view()
        {
            foreach (LineOfTextIF obj in content)
            {
                obj.view();
            }
                
            // End line of text  with line break
            Console.WriteLine("\n");
        }

        public void edit()
        {
            Console.WriteLine("Editted from LineOfText");
        }

        public void delete()
        {
            content.Clear();
;           Console.WriteLine("Deleted from LineOfText");
        }
    }
}
