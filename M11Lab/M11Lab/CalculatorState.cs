namespace M11Lab
{
    internal class CalculatorState
    {

        public virtual void nextState(double num) { }
        public virtual void nextState(Operator op) { }
        public virtual void nextState(Equals eq) { }
    }
}
