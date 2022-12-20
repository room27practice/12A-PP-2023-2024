using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task01();
            Task02();
        }

        private static void Task02()
        {
            var furnitures = new List<Furniture>();
            string pattern = @"^>>([a-zA-Z\s]+)<<([1-9]\d*\.?\d+)!([1-9]\d*)$";
            string input = Console.ReadLine();
            while (input != "Purchase")
            {
                Match fur = Regex.Match(input, pattern);
                if (fur.Success)
                {
                    var currentFurniture = new Furniture()
                    {
                        Name = fur.Groups[1].Value,
                        Price = decimal.Parse(fur.Groups[2].Value),
                        Quantity = int.Parse(fur.Groups[3].Value),
                    };

                    furnitures.Add(currentFurniture);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (Furniture item in furnitures)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine($"Total money spend: {furnitures.Sum(x => x.TotalValue):F2}");
        }

        public static void Task01()
        {
            string emailPattern = @"(?<user>(?<=\s)[a-z]+([\.\-_]?[a-z0-9]+))\@(?<host>[a-z]+([\-\.][a-z]+)+)";
            string userNamePattern = @"((?<=\s)[a-z]+([\.\-_]?[a-z0-9]+))(?=\@([a-z]+([\-\.][a-z]+)+))";

            string input = Console.ReadLine();

            string sanitizedText = Regex.Replace(input, userNamePattern, "****");

            Console.WriteLine(new string('=', 20));
            Console.WriteLine("Cleaned Usernames:");
            Console.WriteLine(sanitizedText);
            Console.WriteLine(new string('=', 20));

            MatchCollection matches = Regex.Matches(input, emailPattern);
            Match onlyFirst = Regex.Match(input, emailPattern);


            Email[] emails = matches
                .Select(m => new Email(m.Groups["user"].ToString(), m.Groups["host"].ToString()))
                .ToArray();

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
                Console.WriteLine("Username: " + match.Groups["user"]);
                Console.WriteLine("Hostname: " + match.Groups["host"]);
                Console.WriteLine(new string('=', 20));
            }

            //string[] results = matches.Select(m => m.Value).ToArray();

            //foreach (string item in results)
            //{
            //    Console.WriteLine(item);
            //}

        }

    }

    public class Email
    {
        public Email(string userName, string hostName)
        {
            UserName = userName;
            HostName = hostName;
        }

        public string UserName { get; set; }
        public string HostName { get; set; }
        public override string ToString()
        {
            return this.UserName + "@" + this.HostName;
        }
    }


    public class Furniture
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue => Price * Quantity;
    }
}