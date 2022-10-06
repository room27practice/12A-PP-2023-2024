using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprajnenie
{
    internal class Animal
    {
        private bool isAlive;
        private int age;
        private static int counterId = 0;
        public Animal(string name, string type)
        {
            Name = name;
            Type = type;
            Age = 0;
            isAlive = true;
            Id = ++counterId;
        }
        public Animal(string name, string type, int age) : this(name, type)
        {
            Age = age;
        }
        public int Id { get; }
        public string Name { get; }
        public string Type { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (value > age && isAlive)
                {
                    age = value;
                }
            }
        }
        public void SayHello()
        {
            Console.WriteLine($"I am {Type}-{Name}. And I am {Age} years old.");
        }
        public string SayMessage(string msg)
        {
            return $"{Name}: {msg}";
        }
        public string Die()
        {
            isAlive = false;
            return $"RIP {Name}- {Type}.";
        }


        public static void Test()
        {
            var anim = new Animal("Sharo", "Dog");
            Console.WriteLine(anim.Name);//Sharo
            // anim.Name = "sadasd";
            Console.WriteLine(anim.Id);//1
            anim.SayHello();


            var a = GetMeEvenNumbers("alabala",1,2,5,7,8);
        }

        public static int[] GetMeEvenNumbers(string msg,params int[] nums)
        {
            return nums.Where(x => x % 2==0).ToArray();
        }

    }
}