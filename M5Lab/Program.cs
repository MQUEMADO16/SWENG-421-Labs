class Program
{
    public static void Main(string[] args)
    {
        OperationFactory myFactory = new OperationFactory();
        OperationIF operator1 = myFactory.create("Sum");

        operator1.compute(5);
        Console.WriteLine(operator1.getValue());
    }
}
