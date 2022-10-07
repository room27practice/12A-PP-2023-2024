
using System;
using System.Linq;

namespace Tema_1_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
          //  Country country = new Country();
            int[] nums = (new[] { 1, 2, 3, 4 }).OrderBy(x => x).ToArray();

            //var calc = new Vtori.Calculator();
            //Console.Write("Vuvedi inchove:");
            //var result = calc.ConvertInchToCm(double.Parse(Console.ReadLine()));
            //Console.WriteLine("Rezultat v cm:" + result);

            //var test = new Purvi.Calculator();

            //var dice1 = new Dice();
            //dice1.Sides = 18;

            //while (true)
            //{
            //    var rollResult = dice1.Roll();
            //    Console.WriteLine("Result from Roll: " + rollResult);
            //    Thread.Sleep(5000);
            //}

            var person1 = new Person();
            person1.Name = "Osama";
            while (true)
            {
                Console.Write($"Kakva e vuzrastta na {person1.Name}:");
                person1.Age = int.Parse(Console.ReadLine());
                Console.WriteLine($"Vuzrastta na {person1.Name} e:{person1.Age}");
                Console.WriteLine(new String('=', 20));
            }


        }
    }
    class Dice
    {
        private int sides = 6;
        private string type;

        public int Sides
        {
            get => sides; set => sides = value;
        }



        public int Roll()
        {
            Random random = new Random();
            int result = random.Next(1, this.sides);
            return result;
        }
    }

    public class Person
    {

        private static string[] countries = { "Bulgaria", "Russia", "Macedonia", "Serbia", "Iraq", "Bangladesh" };

        public string Name { get; set; }

        private int age;

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Nedei pisa gluposti!!!");
                    age = 0;
                    return;
                }
                if (value > 100)
                {
                    Console.WriteLine("Mnogo golqma vuzrast!!!");
                    age = value;
                    return;
                }

                if (value % 2 == 0)
                {
                    age = 2 * value;

                }
                else
                {
                    age = value;
                }


            }
        }





        //    public string Age { get=>age.ToString(); set=>age=int.Parse(value); }

    }


}
