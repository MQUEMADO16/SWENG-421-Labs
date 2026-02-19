namespace M5Lab
{
    public class Log : Operation
    {
        public override void compute()
        {   
            value = Math.Log10(value);
        }

        public override void compute(double x)
        {
            Console.WriteLine("Do not use for log");
        }
    }
}
