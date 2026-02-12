abstract class Operation: OperationIF
{   
    protected static double value = 0;

    // no parameter
    public virtual void compute() {}
    
    // 1 parameter
    public abstract void compute(double x);

    public double getValue()
    {
        return value;
    }
}