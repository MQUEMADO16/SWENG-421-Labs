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
        private string Type = "TV";
        private static string Brand = "Sony";


        public TV_IF replenish(string type, int budget)
        {
            if (type == null)
            {
                if (budget >= 480)
                {
                    return new SonyUltraTV();
                }
                else if (budget >= 380)
                {
                    return new SonySmartTV();
                }
                else if (budget >= 280)
                {
                    return new SonyTV();
                }
            }
            else if (type == "TV" && budget >= 280)
            {
                return new SonyTV();
            }
            else if (type == "Smart_TV" && budget >= 380)
            {
                return new SonySmartTV();
            }
            else if (type == "UltraHD_TV" && budget >= 480)
            {
                return new SonyUltraTV();
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

        public virtual string getInfo()
        {
            return "Type: " + getType() + " | Price: " + getPrice() + " | Brand: " + getBrand();
        }

        protected class SonySmartTV : SonyTV, SmartTV_IF
        {
            public SonySmartTV()
            {
                MSRP = 300;
                Type = "Smart_TV";
            }

            public string getPowerUsage()
            {
                return "5.35 watts/hour";
            }
            public override string getInfo()
            {
                return base.getInfo() + " | Power Usage: " + getPowerUsage();
            }


        }
        protected class SonyUltraTV : SonyTV, UltraHDTV_IF
        {
            public SonyUltraTV()
            {
                MSRP = 450;
                Type = "UltraHD_TV";
            }
            public string getResolution()
            {
                return "4k HD";
            }
            public override string getInfo()
            {
                return base.getInfo() + " | Resolution: " + getResolution();
            }
        }
    }
}
