using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal class Novel : AdministratorIF
    {
        public List<NovelContentIF> content = new List<NovelContentIF>();

        public void save()
        {
            Console.WriteLine("Novel saved successfully.");
            foreach (var child in content) child.save();
        }

        public void retrieve()
        {
            Console.WriteLine("Novel retrieved from archives.");
            foreach (var child in content) child.retrieve();
        }

        public void edit()
        {
            Console.WriteLine("Novel edited.");
            foreach (var child in content) child.edit();
        }

        public void delete()
        {
            Console.WriteLine("Novel deleted completely.");
            foreach (var child in content) child.delete();
        }

        public void view()
        {
            foreach (var child in content) child.view();
        }
    }
}
