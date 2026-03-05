using System;

namespace M7Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Novel novel = new Novel();
            NovelContentIF page = new Page();

            novel.content.Add(page);

            PageContentIF column = new Column();
            PageContentIF frame = new Frame();

            page.content.Add(column);
            page.content.Add(frame);

        }
    }
}