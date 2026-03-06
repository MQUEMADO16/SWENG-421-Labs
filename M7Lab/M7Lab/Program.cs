using System;

namespace M7Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            // SCENARIO 1: Building the Novel Structure
            Character cS = new Character('S');
            Character cW = new Character('W');
            Character cE = new Character('E');
            Character cN = new Character('N');
            Character cG = new Character('G');

            Character c4 = new Character('4');
            Character c2 = new Character('2');
            Character c1 = new Character('1');

            // Create the first LineOfText and add the "SWENG" characters
            LineOfText line1 = new LineOfText();
            line1.content.Add(cS);
            line1.content.Add(cW);
            line1.content.Add(cE);
            line1.content.Add(cN);
            line1.content.Add(cG);

            // Create the second LineOfText and add the "421" characters
            LineOfText line2 = new LineOfText();
            line2.content.Add(c4);
            line2.content.Add(c2);
            line2.content.Add(c1);

            // Create the first Column and add line1
            Column col1 = new Column();
            col1.content.Add(line1);

            // Create the second Column and add line2
            Column col2 = new Column();
            col2.content.Add(line2);

            // Create the Frame and add col2
            Frame frame1 = new Frame();
            frame1.content.Add(col2);

            // Create the Page and add col1 and frame1
            Page page1 = new Page();
            page1.content.Add(col1);
            page1.content.Add(frame1);

            // Create the Novel and add the page
            Novel myNovel = new Novel();
            myNovel.content.Add(page1);


            // SCENARIO 2: Writer invokes View

            Console.WriteLine("Executing Scenario 2");

            // Cast the Novel to the readonly WriterIF interface
            WriterIF writerAccess = (WriterIF)myNovel;

            // The writer calls view on the root node
            writerAccess.view();

            Console.WriteLine();

        }
    }
}