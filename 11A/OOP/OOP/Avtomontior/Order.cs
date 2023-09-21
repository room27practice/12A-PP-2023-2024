using System;

namespace Avtomontior
{
    internal partial class Program
    {
        public class Order
        {
            private decimal price;

            public Order(DateTime date, string description, decimal price)
            {
                var currentTime = DateTime.UtcNow;
                if (date.Year < currentTime.Year)
                {
                    Date = currentTime;
                }
                else
                {
                    Date = date;
                }

                Description = description;
                Price = price;
            }

            public DateTime Date { get; }
            public string Description { get; set; }
            public decimal Price
            {
                get { return price; }
                set
                {
                    if (value <= 0)
                    {
                        price = 0;
                        Console.WriteLine("Invalid Price value!");
                    }
                    else
                    {
                        price = value;
                    }
                }
            }


        }
    }
}
