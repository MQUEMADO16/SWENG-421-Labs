using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6Lab
{
    internal class MultiFormContext : ApplicationContext
    {
        private int openForms;

        public MultiFormContext(params Form[] forms)
        {
            openForms = forms.Length;
            foreach (Form form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref openForms) == 0)
                    {
                        ExitThread();
                    }
                };
                form.Show();
            }
        }
    }
}
