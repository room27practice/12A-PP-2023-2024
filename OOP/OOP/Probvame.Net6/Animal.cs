using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probvame.Net6
{
    internal class Animal
    {
        private int age;
        private static int idCounter = 0;

        ~Animal()
        {
            //Tova e Destruktor kato doide garbage collectora toi se aktivira...
            Console.WriteLine("Fairwell Farewell");
        }
        static Animal()
        {
            Console.WriteLine("Nqkoi me pusna!!!!");
        }


        public Animal()
        {
            idCounter += Step;
            Id = idCounter;
        }


        public Animal(string name, int age = 1) : this()
        {
            Name = "Super " + name;
            this.age = age;
        }


        public static void Reseed(int newStart = 0)
        {
            if (newStart >= 0)
            {
                idCounter = newStart;
            }
        }

        public int[] DoTestThing(bool question)
        {

            var a1 = new Animal();
            var c1 = new Car();
            return new int[5];
        }



        public static int Step { get; set; } = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get => age; set => age = value; }
        public bool Gender { get; set; }
        public string Type { get; set; }


    }
}
