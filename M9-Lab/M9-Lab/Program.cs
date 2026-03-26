using System;

namespace M9_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            CMM machine = new CMM();
            CoffeeIF mocha = new Mocha(1, 1, 0);
            machine.setCoffee(mocha);
            ProgramIF mochaProg = machine.setProgram("Mocha");
            mochaProg.setMachine(machine);
            machine.runProgram();
            Console.WriteLine("Mocha is priced at: " + machine.computePrice());
        }
    }
}