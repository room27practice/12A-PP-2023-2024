using System.Security.Cryptography.X509Certificates;

namespace ScopesDemo
{
    internal class Engine
    {
        public string Name = "Asen";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!!!!");
            int a = 5;

            SuperMan sp = null;
            Console.WriteLine(sp?.Street);

            bool? isSomethingValid = null;

            if (true)
            {
                {

                }
            }

        }

        public bool Metod()
        {
            string chng = "Chestita Nova 2023 godina!";
            Dictionary<int, char> lettersInGreeting = chng.Select(x => x).ToDictionary(x => (int)x, x => x);
            return false;
        }


        public class SuperMan
        {
            public string Street { get; set; } = "Sezam";
            public void Fly()
            {
                string name = (new Engine()).Name;
            }
        }

        public class ElectricCar
        {
            public Manufacturer Manuf { get; set; }

        }
        public class FuelCar
        {
            public Manufacturer Manuf { get; set; }

        }
        public class CoalCar
        {
            public Manufacturer Manuf { get; set; }

        }


    }
}
