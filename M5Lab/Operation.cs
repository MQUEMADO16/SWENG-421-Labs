namespace M5Lab
{
    public abstract class Operation: OperationIF
    {   
        protected static double value = 0;

<<<<<<< HEAD
        public virtual void compute() {}

        public abstract void compute(double x);
=======
    // no parameter
    public virtual void compute() {}
    
    // 1 parameter
    public abstract void compute(double x);
>>>>>>> b63706590b4a58bed05c154f6834a93516c9fe37

        public double getValue()
        {
            return value;
        }
    }
}