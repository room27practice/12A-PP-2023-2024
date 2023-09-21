using System;
using System.Collections.Generic;

namespace Avtomontior
{
    internal partial class Program
    {
        public class Customer
        {
            private static decimal annualRefundCoef = 15;
            private const int maxVIPLvl = 10;
            private List<Order> orders = new List<Order>();


            public Customer(string name, DriverType dType)
            {
                Name = Name;
                DriverType = dType;
            }

            public string Name { get; }

            public string Address { get; set; }
            public DateTime BirthDate { get; }

            public DriverType DriverType { get; set; }

            public int VipLevel { get; private set; } = 0;

            public IReadOnlyCollection<Order> Orders
            {
                get { return orders; }
            }

            public int ImproveVip()
            {
                if (VipLevel == maxVIPLvl)
                {
                    Console.WriteLine($"Maximal VIP= { maxVIPLvl } reached already");
                }
                else
                {
                    VipLevel++;
                }
                return VipLevel;
            }

            public decimal GetSpentMoney()
            {
                decimal totalMoneySpent = 0;
                foreach (var o in Orders)
                {
                    totalMoneySpent += o.Price;
                }
                return totalMoneySpent;
            }
            public void RegisterOrder(Order order)
            {
                decimal myPrice = order.Price * (1 - (annualRefundCoef * VipLevel / (100 * maxVIPLvl)));//0.85
                order.Price = myPrice;
                this.orders.Add(order);
            }

        }
    }
}
