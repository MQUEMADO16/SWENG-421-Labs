using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Image
    {
        private string image;

        public Image(string image)
        {
            this.image = image;
        }

        public void save(string image)
        {
            this.image = image;
            Console.WriteLine("Saved to image");
        }

        public string retrieve()
        {
            Console.WriteLine("Retrieved from image");
            return image;
        }

        public void view()
        {
            Console.WriteLine(image);
        }

        public void edit(string image)
        {
            this.image = image;
            Console.WriteLine("Editted from image");
        }

        public void delete()
        {
            image = ""
;           Console.WriteLine("Deleted from image");
        }
    }
}
