class Log : Operation
{
    public override void compute()
    {   
        value = Math.Log(value);
    }

    public override void compute(double x)
    {
        Console.WriteLine("Do not use for log");
    }
}