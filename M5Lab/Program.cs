class Program
{
    public static void Main(string[] args)
    {
        OperationFactory myFactory = new OperationFactory();
        OperationIF operatorAddition = myFactory.create("Sum");
        OperationIF operatorLog = myFactory.create("Log");

        operatorAddition.compute(5);
        Console.WriteLine(operatorAddition.getValue());

        operatorLog.compute();
        Console.WriteLine(operatorLog.getValue());
    }
}
