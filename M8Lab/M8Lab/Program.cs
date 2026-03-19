namespace M8Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Buyer b = new Buyer();
            Customer c = new Customer();
            b.tv = new TV();
            b.tv = b.tv.replenish(null, 100);
            Console.WriteLine(b.tv.getInfo());
        }
    }
}