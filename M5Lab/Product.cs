namespace M5Lab
{
    public class Product : Operation
    {
        public override void compute(double x)
        {   
            value *= x;
        }
    }
}
