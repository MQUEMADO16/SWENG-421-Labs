using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M8Lab
{
    internal class SonyTV : TV_IF
    {
        private int MSRP = 280;
        private string Type = "Regular";
        private static string Brand = "Sony";

        public TV_IF replenish(string type, int budget)
        {
            if (type == null)
            {
                if (budget >= 480)
                {
                    return new UltraTV();
                }
                else if (budget >= 380)
                {
                    return new SmartTV();
                }
                else if (budget >= 280)
                {
                    return new TV();
                }
            }
            else if (type == "Regular" && budget >= 280)
            {
                return new TV();
            }
            else if (type == "Smart" && budget >= 380)
            {
                return new SmartTV();
            }
            else if (type == "Ultra" && budget >= 480)
            {
                return new UltraTV();
            }

            return null;
        }

        public string getType()
        {
            return Type;
        }

        public int getPrice()
        {
            return MSRP;
        }

        public string getBrand()
        {
            return Brand;
        }

        public string getPowerUsage()
        {
            return "5.5 watts/hour";
        }

        public string getResolution()
        {
            return "4k HD";
        }

        public virtual string getInfo()
        {
            return "Type: " + getType() + " | Price: " + getPrice() + " | Resolution: " + getResolution() + " | Power Usage: " + getPowerUsage() + " | Brand: " + getBrand();
        }

        protected class SonySmartTV : SonyTV
        {
            public SonySmartTV()
            {
                MSRP = 300;
                Type = "Smart";
            }
        }
        protected class SonyUltraTV : SonyTV
        {
            public SonyUltraTV()
            {
                MSRP = 400;
                Type = "Ultra";
            }
        }
    }
}
