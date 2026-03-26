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

            CoffeeIF espresso = new Espresso(1, 1, 2);
            machine.setCoffee(espresso);
            ProgramIF espressoProg = machine.setProgram("Espresso");
            espressoProg.setMachine(machine);
            machine.runProgram();
            Console.WriteLine("Espresso is priced at: " + machine.computePrice());
        }
    }
}