namespace M8Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Buyer b = new Buyer();
            Customer c = new Customer();
            b.tv = new TV();
            b.tv = b.tv.replenish(null, 209);

            if (b.tv != null)
            {
                Console.WriteLine(b.tv.getInfo());
            }

            b.tv = new TV();
            b.tv = b.tv.replenish(null, 310);

            if (b.tv != null)
            {
                Console.WriteLine(b.tv.getInfo());
            }

            b.tv = new TV();
            b.tv = b.tv.replenish(null, 430);

            if (b.tv != null) {
                Console.WriteLine(b.tv.getInfo());
            }

            c.tvif =  new SonyTV();
            c.tvif = c.tvif.replenish(null, 556);

            if (c.tvif != null) 
            {
                Console.WriteLine(c.tvif.getInfo());
            }

            c.tvif = new LGTV();
            c.tvif = c.tvif.replenish(null, 250);
            if (c.tvif != null)
            {
                Console.WriteLine(c.tvif.getInfo());
            }

            c.tvif = new LGTV();
            c.tvif = c.tvif.replenish(null, 357);
            if (c.tvif != null)
            {
              Console.WriteLine(c.tvif.getInfo());
            }
            c.tvif = new SonyTV();
            c.tvif = c.tvif.replenish(null, 380);
            if (c.tvif != null)
            {
                Console.WriteLine(c.tvif.getInfo());
            }
            c.tvif = new LGTV();
            c.tvif = c.tvif.replenish(null, 600);
            if (c.tvif != null)
            {
                Console.WriteLine(c.tvif.getInfo());
            }
        }
    }
}