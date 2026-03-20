using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M8Lab
{
    internal class LGTV : TV_IF
    {
        private int MSRP = 250;
        private string Type = "TV";
        private static string Brand = "LG";


        public TV_IF replenish(string type, int budget)
        {
            if (type == null)
            {
                if (budget >= 450)
                {
                    return new LGUltraTV();
                }
                else if (budget >= 350)
                {
                    return new LGSmartTV();
                }
                else if (budget >= 250)
                {
                    return new LGTV();
                }
            }
            else if (type == "TV" && budget >= 250)
            {
                return new LGTV();
            }
            else if (type == "Smart_TV" && budget >= 350)
            {
                return new LGSmartTV();
            }
            else if (type == "UltraHD_TV" && budget >= 450)
            {
                return new LGUltraTV();
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

        protected class LGSmartTV : LGTV, SmartTV_IF
        {
            public LGSmartTV()
            {
                MSRP = 350;
                Type = "Smart_TV";
            }
            public string getPowerUsage()
            {
                return "6.35 watts/hour";
            }
            public override string getInfo()
            {
                return base.getInfo() + " | Power Usage: " + getPowerUsage();
            }
        }
        protected class LGUltraTV : LGTV, UltraHDTV_IF
        {
            public LGUltraTV()
            {
                MSRP = 450;
                Type = "UltraHD_TV";
            }

            public string getResolution() => "4k HD";

            public override string getInfo()
            {
                return base.getInfo() + " | Resolution: " + getResolution();
            }
        }
    }
}
