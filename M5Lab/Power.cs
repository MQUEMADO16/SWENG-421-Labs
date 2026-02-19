namespace M5Lab
{
    public class Power : Operation
    {
        public override void compute(double x)
        {   
            value = Math.Pow(value, x);
        }
    }
}
