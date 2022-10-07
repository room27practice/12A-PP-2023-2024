namespace Uprajnenie
{
    internal class Animal
    {
        #region fields
        private bool isAlive;
        private int age;
        private static int counterId = 0;
        #endregion

        ~Animal()
        {
            Console.WriteLine($"Animal {Name} was killed by Garbage Collector!");
        }

        public Animal()
        {
            isAlive = true;
            Id = ++counterId;
            Age = 0;
        }
        public Animal(string name, string type) : this()
        {
            Name = name;
            Type = type;
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
            var anim1 = new Animal("ala", "bala");


            var anim = new Animal("Sharo", "Dog");
            Console.WriteLine(anim.Name);//Sharo
            // anim.Name = "sadasd";
            Console.WriteLine(anim.Id);//1
            anim.SayHello();

            var a = GetMeEvenNumbers("alabala", 1, 2, 5, 7, 8);
        }

        public static int[] GetMeEvenNumbers(string msg, params int[] nums)
        {
            return nums.Where(x => x % 2 == 0).ToArray();
        }

    }
}