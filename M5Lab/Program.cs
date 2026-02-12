using System.Diagnostics;

namespace M5Lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OperationFactoryIF myFactory = new OperationFactory();
            OperationIF operatorAddition = myFactory.create("Sum");
            OperationIF operatorLog = myFactory.create("Log");

            operatorAddition.compute(5);
            Debug.WriteLine(operatorAddition.getValue());

            operatorLog.compute();
            Debug.WriteLine(operatorLog.getValue());
        }
    }

}
