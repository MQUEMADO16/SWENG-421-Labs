namespace Final.Alerts.Decorators
{
    public abstract class AlertDecorator : IAlert
    {
        protected IAlert _alert;

        public AlertDecorator(IAlert alert)
        {
            _alert = alert;
        }

        public void setAlert(IAlert alert)
        {
            _alert = alert;
        }

        public virtual string sendAlert()
        {
            return _alert.sendAlert();
        }
    }
}