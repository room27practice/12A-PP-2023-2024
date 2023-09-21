namespace AnonimousDemo
{
    internal class Program
    {
        static void Main()
        {
            var p1 = new Person { Name = "Father" };

            var test1 = new { Name = "Marin", Age = 17, Gender = Gender.Male, Parent = p1 };

            Console.WriteLine(test1.Name);
            Console.WriteLine(test1.Age);

        }

        public static void PrintName(Person p)
        {
            var test1 = new { Name = "AliBaba", Age = 37, Gender = Gender.Male, Parent = new Person { Name = "Aladin" } };

            Console.WriteLine(p.Name);
        }

        //public static void PrintNameOfAnonimous({string Name} p)
        //{
        //    Console.WriteLine(p.Name);
        //}


    }


    public class Person
    {
        public string Name { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }

}