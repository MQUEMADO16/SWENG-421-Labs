using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace M9_Lab
{
    internal class CMM
    {
        private CoffeeIF? cif;
        private ProgramIF? pif;

        public ProgramIF setProgram(int num)
        {
            switch (num)
            {
                case 0:
                    this.pif = new RegularProg();
                    return pif;
                case 1:
                    this.pif = new MochaProg();
                    return pif;
                case 2:
                    this.pif = new CappuccinoProg();
                    return pif;
                default:
                    this.pif = new RegularProg();
                    return pif;
            }
        }

        public ProgramIF setProgram(string programName)
        {
            switch (programName)
            {
                case "Regular":
                    this.pif = new RegularProg();
                    return pif;
                case "Mocha":
                    this.pif = new MochaProg();
                    return pif;
                case "Cappuccino":
                    this.pif = new CappuccinoProg();
                    return pif;
                default:
                    this.pif = new USBProg();
                    return pif;
            }
        }

        public void setGrindingTime(int secs)
        {
            Console.WriteLine("Grinding for " + secs + " seconds");
        }

        public void setTemperature(int degree)
        {
            Console.WriteLine("Set temperature to " + degree);
        }

        public void setCoffee(CoffeeIF cif)
        {
            this.cif = cif;
        }

        public void setLEDNum(int num)
        {
            switch (num)
            {
                case 0:
                    Console.WriteLine("Set LED to regular");
                    break;
                case 1:
                    Console.WriteLine("Set LED to mocha");
                    break;
                case 2:
                    Console.WriteLine("Set LED to cappuccino");
                    break;
                case 3:
                    Console.WriteLine("Set LED to custom");
                    break;
                case -1:
                    Console.WriteLine("Set LED to idle");
                    break;
                default:
                    Console.WriteLine("Set LED to idle");
                    break;
            }
        }

        public void runProgram()
        {   
            if(pif != null)
            {
                pif.run();
            }

        }

        public double computePrice()
        {
            if (cif != null)
            {
                return cif.computePrice();
            }
            else return -1;
        }

    }
}
