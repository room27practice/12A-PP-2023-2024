using System;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
         //   Animal a1 = new Animal();//Ако е зададен като абстрактен не ми се позволява.
            Console.WriteLine(new String('=', 30));
            Dog d1 = new Dog();
            Console.WriteLine(new String('=', 30));
            Cat c1 = new Cat();
            Console.WriteLine(new String('=', 30));
            Animal c2 = new Cat();
            Console.WriteLine(c2.GetPoints());
            Console.WriteLine(d1.GetPoints());
            object a5 = new Cat();

            d1.PresentYourSlef();
            d1.UserName = "Ivan";
            d1.Age = 10;
            d1.Breed = "Pekinez";
            d1.SayHello();

            var arr = new int[] { 1, 2, 3, 5 };

            arr[0] = 55;


            Animal[] animals = new Animal[] { c1, d1, a1 };
            foreach (Animal animal in animals)
            {
                Console.WriteLine("I am {0}. I am {1} yars old", animal.UserName, animal.Age);
                if (animal is Cat)
                {
                    int lives = ((Cat)animals[0]).RemainingLives;
                    Console.WriteLine("I am cat and I have {0}", lives);
                }
                if (animal is Dog)
                {

                }

            }

            var d5 = new Dog(6, "Sharo");


        }
    }






    public abstract class Animal
    {
        public string Type { get; private set; }
        protected Animal(string type, string name)
        {
            Type = type;
            UserName = name;
        }

        protected Animal()
        {
            Console.WriteLine("Animal Constructor was called");
        }
        protected double weight = 10;
        public int Age { get; set; }
        public string UserName { get; set; } = string.Empty;

        public void PresentYourSlef()
        {
            Console.WriteLine($"I am {UserName}. And I am {Age} years old." + weight);
        }

        public abstract int GetPoints();
       

    }


    public class Dog : Animal
    {
        public Dog(int a, string nme = "UnknownName") : base("Dog", nme)
        {

        }
        public Dog()
        {
            Console.WriteLine("Dog Constructor was called");
        }
        public string Breed { get; set; }

        public void SayHello()
        {
            Console.WriteLine("Woof Woof!" + weight);
        }

        public override int GetPoints()
        {
            return 10;
        }
    }
    public class Cat : Animal
    {

        public Cat(string name = "UnknownName") :base("Cat",name)
        {

        }
        public string Breed { get; set; } = string.Empty;
        public int RemainingLives { get; set; } = 7;

        public override int GetPoints()
        {
            return Age * 2;
        }

        public void SayHello()
        {
            Console.WriteLine("Mew Mew!");
        }
    }


    public class Cat2
    {
        public string Breed { get; set; } = string.Empty;
        public int RemainingLives { get; set; } = 7;

        public void SayHello()
        {
            Console.WriteLine("Mew Mew!");
        }

        public int Age { get; set; }
        public string Name { get; set; } = string.Empty;

        public void PresentYourSlef()
        {
            Console.WriteLine($"I am {Name}. And I am {Age} years old.");
        }

    }

}
