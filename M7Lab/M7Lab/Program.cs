using System;

namespace M7Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Character myCharacter = new Character('h');
            Character myCharacter2 = new Character('i');

            LineOfText lineOfText = new LineOfText();
            lineOfText.save(myCharacter);
            lineOfText.save(myCharacter2);
            lineOfText.view();
        }
    }
}