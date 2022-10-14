using System;

namespace Avtomontior
{
    internal partial class Program
    {
        static void Main()
        {

            // Order o1 = new Order();
            Customer c1 = new Customer("Kuncho", DriverType.Bycicle);
            //  c1.VipLevel = 2;

            Console.WriteLine(c1.VipLevel);
            c1.ImproveVip();
            c1.ImproveVip();
            c1.ImproveVip();
            Console.WriteLine(c1.VipLevel);


            var order1 = new Order(DateTime.UtcNow, "smqna na maslo", 30m);
            var order2 = new Order(DateTime.UtcNow.AddDays(2), "Podmqna na zaden most", 20m);

            c1.RegisterOrder(order1);
            c1.RegisterOrder(order2);
            Console.WriteLine(c1.GetSpentMoney());

        }
    }
}
