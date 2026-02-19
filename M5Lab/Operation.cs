namespace M5Lab
{
    public abstract class Operation: OperationIF
    {   
        protected static double value = 0;

        public virtual void compute() {}

        public abstract void compute(double x);

        public double getValue()
        {
            return value;
        }
    }
}