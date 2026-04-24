using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal abstract class AlertDecorator
    {
        private Alert alert;

        public void setAlert(Alert alert)
        {
            this.alert = alert;
        }

        public string sendAlert()
        {
            return alert.sendAlert();
        }
    }
}
