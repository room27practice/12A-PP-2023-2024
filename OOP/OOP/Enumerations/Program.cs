using System;
using System.Collections.Generic;
using System.Linq;

namespace Enumerations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Manufaturer");
            var man = Console.ReadLine();
            var weight = double.Parse(Console.ReadLine());
            Season s1;
            while (!Enum.TryParse<Season>(Console.ReadLine(), out s1))
            {
                Console.WriteLine("Vuvedi veren sezon!!!");
            }


            Console.WriteLine("My inputed season is with number: " + (int)s1);

            var tyre1 = new Tyre(s1, man, 2);
            var tyre2 = new Tyre(Season.Summer, man, 3);
            var tyre3 = new Tyre((Season)3, man, 4);
            var gumi = new Tyre[] { tyre1, tyre2, tyre3 };

            var obshotTeglo = gumi.Sum(x => x.Weight);
          
        }
    }

    public class Tyre
    {
        private List<Repair> repairs;

        public Tyre(Season season, string manufactur, double weight)
        {
            Season = season;
            Manufactur = manufactur;
            Weight = weight;
            repairs = new List<Repair>();
        }

        public Season Season { get; set; }
        public string Manufactur { get; set; }
        public double Weight { get; set; }
        public AllowedColors Color { get; set; } = AllowedColors.Green;
  
        public IReadOnlyCollection<Repair> Repairs =>repairs;
        public List<string> Labels { get; set; } = new List<string>();
    }

    public class Repair
    {
        public string WorkerName { get; set; }
        public DateTime DateOfRepair { get; set; }
        public decimal Cost { get; set; }
        public Severity Severity { get; set; }
    }

    public enum Severity
    {
        VeryBad, NotSoGood, AlmostDestroyed, Critical
    }
}
