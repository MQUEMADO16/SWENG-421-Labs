using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Image : FrameContentIF, LineOfTextContentIF
    {
        private string imageName;

        public Image(string name)
        {
            this.imageName = name;
        }

        public void save()
        {
            Console.WriteLine($"Image '{imageName}' saved.");
        }

        public void retrieve()
        {
            Console.WriteLine($"Image '{imageName}' loaded.");
        }

        public void edit()
        {
            Console.WriteLine($"Image '{imageName}' edited.");
        }

        public void delete()
        {
            Console.WriteLine($"Image '{imageName}' deleted.");
        }

        public void view()
        {
            Console.Write($"[Img:{imageName}]");
        }
    }
}
