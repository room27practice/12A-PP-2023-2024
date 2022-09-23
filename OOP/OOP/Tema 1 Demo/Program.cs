
using System;
using System.Linq;
using System.Threading;

namespace Tema_1_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = (new int[6]).OrderBy(x => x).ToArray();



            //var calc = new Vtori.Calculator();
            //Console.Write("Vuvedi inchove:");
            //var result = calc.ConvertInchToCm(double.Parse(Console.ReadLine()));
            //Console.WriteLine("Rezultat v cm:" + result);


            //var test = new Purvi.Calculator();

            var dice1 = new Dice();
            dice1.Sides = 18;
            
            while (true)
            {
                var rollResult = dice1.Roll();
                Console.WriteLine("Result from Roll: " + rollResult);
                Thread.Sleep(5000);
            }
        }
    }
    class Dice
    {
        private int sides = 6;
        private string type;

        public int Sides
        {
            get => sides;  set => sides = value;
        }

   

        public int Roll()
        {
            Random random = new Random();
            int result = random.Next(1, this.sides);
            return result;
        }
    }
}
