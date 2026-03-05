using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Image : LineOfTextContentIF, FrameContentIF, ColumnContentIF
    {
        private string image = "";

        public Image() { }

        public void save()
        {
            Console.WriteLine("Saved to image");
        }

        public void retrieve()
        {
            Console.WriteLine("Retrieved from image");
        }

        public void view()
        {
            Console.WriteLine("Viewed from image");
        }

        public void edit()
        {
            Console.WriteLine("Editted from image");
        }

        public void delete()
        {
            Console.WriteLine("Deleted from image");
        }
    }
}
