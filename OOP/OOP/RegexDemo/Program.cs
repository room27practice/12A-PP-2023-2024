using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task01();
            Task02();
        }

        private static void Task02()
        {
            throw new NotImplementedException();
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
                Console.WriteLine(new string('=',20));
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
            return this.UserName+"@"+this.HostName;
        }
    }
}