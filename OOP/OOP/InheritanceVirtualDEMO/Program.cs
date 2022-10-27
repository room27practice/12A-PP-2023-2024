using System;

namespace InheritanceVirtualDEMO
{
    public class Program
    {
        static void Main(string[] args)
        {
            var test1 = new TestAutoProperty();

            int res1 = test1.GetNumber(7);

            Console.WriteLine(test1.GetNum);

            //  var a1 = new Animal();


            //Dog d1 = new Dog();

            //d1.PresentYourself();

            Animal d2 = new Dog();

            d2.PresentYourself();
            Console.WriteLine(d2.GetSound());    
            Console.WriteLine(new String('=',20));
            Animal c1 = new Cat();
            c1.PresentYourself();
        }
    }


    public abstract class Animal
    {
        public int MaxAge { get; set; }
        public double MaxWeight { get; set; }
        public bool CanFly { get; set; }
        public bool CanSwim { get; set; }
        public abstract string GetSound();
        public virtual void PresentYourself()
        {
            Console.WriteLine("Hello I am basic Animal.");
        }
        public void Tralalala()
        {
            Console.WriteLine("Neshto");
        }

    }

    public abstract class Mammel : Animal
    {
        public bool TailLenght { get; set; }
        public int VisibleColors { get; set; }

        public override void PresentYourself()
        {
            base.PresentYourself();

            Console.WriteLine("I am also a mammel");
        }
    }
    public class Cat : Mammel
    {
        public override string GetSound()
        {
            return "Mew Mew";
        }
        public override sealed void PresentYourself()
        {
            base.PresentYourself();
            Console.WriteLine("I am also a cat");
        }
    }

    public class Dog : Mammel
    {
        public override string GetSound()
        {
            return "Woof Woof";
        }
        public override sealed void PresentYourself()
        {
            base.PresentYourself();
            Console.WriteLine("I am also a dog");
        }

    }
    public class Puppy : Dog
    {

    }






    public class TestAutoProperty
    {
        public int GetNum => 10 + GetNumber(54);


        public int GetNumber(int anotherNumber)
        {
            return anotherNumber * 5;
        }
    }


}
