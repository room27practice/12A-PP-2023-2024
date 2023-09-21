using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Interfeisi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool hasDigits = @"http://softuni.bg http://youtube.com http://www.g00gle.com".Any(x => Char.IsDigit(x));

          
            

            int[] arr = new int[5];
            var something = arr.Select(x => x);
            int b333 = 43;


            Hero h1 = new Hero();

            INamable t1 = h1 as INamable;
            Console.WriteLine(t1?.Name);


            Bird b1 = new Bird();

            INamable t2 = b1 as INamable;
            Console.WriteLine(t2.Name + "ne stana");

            var val1 = ((INamable)h1).ExplicitStuff; //Explicit 
            var gurmi = ((INamable)new Bird()).ExplicitStuff; //Explicit 
            PrintMyName(h1);


            AngryBird ab = new AngryBird();
            var val2 = ab.ExplicitStuff; //Implicit

            Hero test = new Hero();

            test.DoSomething();

            ILevelUpgradeable a = new Hero() { Name = "Kiroslav" };

            AngryBird b = new AngryBird() { Name = "Patka" };


            List<IKillable> prisoners = new List<IKillable>();
            prisoners.Add((IKillable)a);
            prisoners.Add(b);


            foreach (IKillable prisoner in prisoners)
            {
                PrintMyName((INamable)prisoner);
                prisoner.Die();
            }
        }

        static void PrintMyName(INamable something)
        {
            Console.WriteLine($"My name is {something.Name} {something.ExplicitStuff}");
        }
    }

    public interface INamable
    {
        string Name { get; set; }
        //  string Address { get; set; }
        string ExplicitStuff { get; set; }
        public void DoSomething();



    }


    public interface IKillable
    {
        bool IsAlive { get; set; }

        void Die();


        //{
        //    Console.WriteLine("asdasd");
        //}
    }

    public interface ILevelUpgradeable
    {
        int ImproveLevel();
    }


    public class Hero : IKillable, ILevelUpgradeable, INamable
    {
        private int level = 1;
        public bool IsAlive { get; set; }
        public int Age { get; set; }
        public string Name { get; set; } = "Kuncho";
        string INamable.ExplicitStuff { get; set; }

        public void Die()
        {
            Console.WriteLine("I die well..."); ;
        }

        public int ImproveLevel()
        {
            return ++level;
        }

        public void DoSomething()
        {
            Console.WriteLine("Another Thing");
        }
    }

    public class Bird
    {
        private string imageUrl;
        public double HeightOfFlying { get; set; }
        public string Breed { get; set; }


    }


    public class AngryBird : Bird, IKillable, INamable
    {
        public int AngrinessLevel { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public string ExplicitStuff { get; set; }

        public void Die()
        {
            Console.WriteLine("We all live in a yellow submarine.");
        }

        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }


    public class SuperAngryBird : AngryBird
    {

    }

    public class MySuperDuperCollection<Hero> : IEnumerable<Hero>
    {
        public IEnumerator<Hero> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}