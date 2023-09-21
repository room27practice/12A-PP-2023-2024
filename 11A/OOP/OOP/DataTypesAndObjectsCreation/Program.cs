using System;
using System.Linq;

namespace DataTypesAndObjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item = new
            {
                Name = "chushkopek",
                Price = 24,
                Weight = 2
            };           
            
            Dog dog1 = new Dog();

            dog1.Id = 32;
            dog1.Name = "Sharo";

            Dog dog2 = new Dog()
            {  Name = "Mecho", Gender = true, Breed = "San Bernar" };

            Console.WriteLine(dog2.Name);

            dog2.Name = "Marko";

            Dog snoopDog;// Това ще е null защото не е дефинирано


            var copyDog = dog2;
            Console.WriteLine(copyDog.Name);
            copyDog.Name = "Genadi";
            Console.WriteLine(dog2.Name);
            Console.WriteLine(copyDog.Name);


            int[] nums = new int[4] { 1, 2, 34, 4 };

            int[] alabala = nums.ToArray();

            alabala[1] = 444;

            dog1.FavoriteNumbers = new int[] {1, 3, 4, 5};

            dog2.FavoriteNumbers = dog1.FavoriteNumbers;
            dog2.FavoriteNumbers[3] = 99;

            dog1.Parent = null;
            dog2.Parent = dog1;
            dog1.Name = "Petur";
            dog2.Parent.Name = "Petur";

            dog2.GetOlder();
            dog2.PresentSelf();

            Dog[] dogs = new Dog[] { dog1, dog2 };

            foreach (Dog dog in dogs)
            {
                dog.PresentSelf();
                dog.GetOlder();
                dog.Name = dog.Name + " bau bau!";
            }

        }
         
    }




    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; private set; } = 0;
        public bool Gender { get; set; }
        public string Breed { get; set; }
        public int[] FavoriteNumbers { get; set; }
        public Dog Parent { get; set; }
        public bool IsAlive { get; private set; } = true;

        public void PresentSelf()
        {
            #region IfAlternativeToTernaryOperator
            //if (Age < 2)
            //{
            //    Console.WriteLine("I am a puppy");
            //}
            //else
            //{
            //    Console.WriteLine("I am a dog");
            //}
            #endregion
            string dogType = Age < 2 ? "puppy" : "dog";
            // string dogType = Age < 2 ? "puppy" : Age <= 5 ? "infant" : "dog";
            Console.WriteLine($"I am a {dogType}");
            Console.WriteLine($"My Name is {Name}. My breed is {Breed}");
            if (Parent !=null)
            {
            Console.WriteLine($"My parentName is {Parent.Name}.");                
            }
        }
        public void GetOlder()
        {
            if (!IsAlive)
            {
                return;
            }
            Age++;
        }
    }
}
