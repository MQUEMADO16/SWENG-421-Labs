abstract class Operation: OperationIF
{   
    protected static double value = 0;
    public abstract void compute(double x);

    public double getValue()
    {
        return value;
    }
}