using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7Lab
{
    internal interface NovelContentIF
    {
        List<PageContentIF> content { get; }
        public void save();
        public void retrieve();
        public void view();
        public void edit();
        public void delete();
    }
}
