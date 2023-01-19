using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task01();
            // Task02();
            // Task03();

            int a = 5;
            int b = 0;
            //if (a % 2 == 0)
            //{
            //    b = 2 * a;//10
            //}
            //else
            //{
            //    b = 2 + a;//7
            //}

            //b = (a % 2 == 0) ? 2 * a : 2 + a;


            if (a % 2 == 0)
            {
                b = 2 * a;//10
            }
            else if (a > 10)
            {
                b = 2 + a;//7
            }
            else
            {
                b = -12;
            }

            b = (a % 2 == 0) ? (2 * a) : (a > 10) ? (2 + a) : (-12);

            Console.WriteLine($"{(a % 2 == 0 ? "Chisloto e chetno" : "po")} Nqkvi drugi neshta");


        }

        private static void Task03()
        {
            string pattern = "(?<=body>)(((?:<.+>)*.*)+)(?=</body)";
            string data = "<!DOCTYPE html> <html lang=\"en\"> <head> <meta charset=\"UTF-8\"> <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"> <title>Shop</title> <script src=\"https://kit.fontawesome.com/e81cea22e8.js\" crossorigin=\"anonymous\"></script> <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css\"> <link rel=\"stylesheet\" href=\"../css/reseter.css\"> <link rel=\"stylesheet\" href=\"../css/style.css\"> <link rel=\"stylesheet\" href=\"../css/responsive.css\"> </head> <body> <header> <div class=\"container\"> <nav> <ul> <div class=\"align-items-center\" style=\"font-size: 26px;\"><!--Може би е излишно!--> <div class=\"col\" style=\"width: 40%; margin-top: 5px;\"> <li class=\"item item-color\"><a href=\"#\">Furniture</a></li> <li class=\"item item-color\"><a href=\"#\">Outdoor</a></li> <li class=\"item item-color\"><a href=\"#\">Storage</a></li> <li class=\"item item-color\"><a href=\"#\">Lighting</a></li> <li class=\"item item-color\" id=\"gap\"><a href=\"#\">Appliances</a></li> </div> <div class=\"col\" style=\"float: right;\"> <li class=\"item item2\"> <div style=\"transform: translate(-00%, -20%);\"> <input type=\"text\" placeholder=\"Search anything...\" style=\"border: none; margin-left: 5px; padding: 30px auto;\"> <i class=\"fa-solid fa-magnifying-glass fa2\"></i> </div> </li> <li class=\"item item3 item-color\" style=\"transform: translate(-00%, -20%);\"><i class=\"fa-solid fa-user\"></i><a href=\"#\">My Account</a></li> </div> </div> </ul> </nav> </div> </header> <section class=\"Rooms\"> <div class=\"images\"> <div class=\"container2\"> <div class=\"col\"> <img src=\"../images/liv-room.jpg\"> <p>Living Room</p> </div> <div class=\"col\"> <img src=\"../images/kitchen.jpg\"> <p>Kitchen</p> </div> <div class=\"col\"> <img src=\"../images/bedroom.jpg\"> <p>Bedroom</p> </div> <div class=\"col\" style=\"padding-right: 20px!important;\"> <img src=\"../images/bathroom.jpg\"> <p>Bathroom</p> </div> </div> <div class=\"container3\"> <div style=\"margin-right: auto; font-size: 20px;\"> <p class=\"header1\">News Fall Collection</p> <p class=\"text\">Check out our brand new fall items!</p> <button class=\"buttons\">Shop Now</button> </div> <img src=\"../images/fall-collection.jpg\" class=\"bigimage\"> </div> </div> </section> <section class=\"Shipping\"> <div class=\"container4\"> <div class=\"container-adv\"> <div class=\"col-adv\"> <img src = \"../images/free-shipping.png \" class=\"adv\"> <b><h1 class=\"h1\">FREE SHIPPING</h1></b> <p class=\"p1\">On everything over $50.</p> </div> <div class=\"col-adv\"> <img src = \"../images/amazing-deals.png\"class=\"adv\"> <h1 class=\"h1\">AMAZING DEALS</h1> <p class=\"p1\">Save up to 70% on high-quality furniture.</p> </div> <div class=\"col-adv\"> <img src = \"../images/customer-service.png \"class=\"adv\"> <h1 class=\"h1\">TOP CUSTOMER SERVCE</h1> <p class=\"p1\">We're glad to help you pick the best item.</p> </div> </div> </div> <section class=\"section5\"> <div class=\"container-footer\"> <ul> <div class=\"align-items-center\" style=\"padding: 20px 10px 40px 10px;\"> <div class=\"col\" style=\" margin-top: 5px;\"> <li class=\"item\" style=\"margin-left: 0px;\"><a href=\"#\" id=\"color-link\"><b>About Us</b></a></li> <li class=\"item\"><a href=\"#\" id=\"color-link\">Locations</a></li> <li class=\"item\"><a href=\"#\" id=\"color-link\">Return Policy</a></li> <li class=\"item\"><a href=\"#\" id=\"color-link\">Complaints</a></li> <li class=\"item\" id=\"gap\"><a href=\"#\" id=\"color-link\">Gift Cards</a></li> </div> <div class=\"col\" style=\"float: right;\"> <li class=\"item\"><a href=\"#\" id=\"color-link\"><b>Contact Us</b></a></li> <button class=\"btn-footer\">Call</button> <li id=\"time\" class=\"item\"><a href=\"#\" id=\"color-link\">Mon-Fri: 8AM - 10PM</a></li> <li id=\"color-link\" class=\"item\"> <a href=\"#\"> <i class=\"fa-brands fa-square-facebook\"></i> </a> <a href=\"#\"> <i class=\"fa-brands fa-instagram\"></i> </a> <a href=\"#\"> <i class=\"fa-brands fa-twitter\"></i> </a> <a href=\"#\"> <i class=\"fa-brands fa-pinterest\"></i> </a> </li> </div> </div> </ul> </div> </section> </body> </html>";
            Match match = Regex.Match(data, pattern);
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