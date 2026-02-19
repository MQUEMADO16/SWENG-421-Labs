namespace M5Lab
{
    public class Sum : Operation
    {
        public override void compute(double x)
        {   
            value += x;
        }
    }
}
