namespace M5Lab
{
    public class Subtract : Operation
    {
        public override void compute(double x)
        {   
            value -= x;
        }
    }
}
