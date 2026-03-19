using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M8Lab
{
    internal class TV : TV_IF
    {
        private int MSRP = 200;
        private string Type = "Regular";

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
            } else if(type == "Smart" && budget >=300)
            {
                return new SmartTV();    
            } else if(type == "Ultra" && budget >= 400)
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

        public string getInfo()
        {
            return "Type: " + getType() + " | Price: " + getPrice();
        }

        protected class SmartTV : TV
        {
            public SmartTV()
            {
                MSRP = 300;
                Type = "Smart";
            }

            public string getPowerUsage()
            {
                return "5.5 watts/hour";
            }
        }
        protected class UltraTV : TV
        {
            public UltraTV()
            {
                MSRP = 400;
                Type = "Ultra";
            }

            public string getResolution()
            {
                return "2K HD";
            }
        }
    }
}
