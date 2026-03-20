using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M8Lab
{
    internal class TV
    {
        private int MSRP = 200;
        private string Type = "TV";

        public TV replenish(string type, int budget)
        {   
            if (type == null)
            {
                if (budget >= 400) {
                    return new UltraTV();
                } else if (budget >= 300)
                {
                    return new SmartTV();
                } else if (budget >= 200)
                {
                    return new TV();
                }
            } else if(type == "TV" && budget >= 200)
            {
                return new TV();
            } else if(type == "Smart_TV" && budget >=300)
            {
                return new SmartTV();    
            } else if(type == "UltraHD_TV" && budget >= 400)
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

        public virtual string getInfo()
        {
            return "Type: " + getType() + " | Price: " + getPrice();
        }

        protected class SmartTV : TV
        {
            public SmartTV()
            {
                MSRP = 300;
                Type = "Smart_TV";
            }

            public string getPowerUsage()
            {
                return "5.5 watts/hour";
            }

            public override string getInfo()
            {
                return "Type: " + getType() + " | Price: " + getPrice() + " | Power Usage: " + getPowerUsage();
            }
        }
        protected class UltraTV : TV
        {
            public UltraTV()
            {
                MSRP = 400;
                Type = "UltraHD_TV";
            }

            public string getResolution()
            {
                return "2K HD";
            }

            public override string getInfo()
            {
                return "Type: " + getType() + " | Price: " + getPrice() + " | Resolution: " + getResolution();
            }
        }
    }
}
