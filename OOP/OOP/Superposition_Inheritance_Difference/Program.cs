using System;
using System.Collections.Generic;

namespace Superposition_Inheritance_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(5);
            Console.WriteLine(5.5);
            Console.WriteLine(true);
            Console.WriteLine(false.ToString());

            int[] arr = new int[5];
            Stack<int> st = new Stack<int>();
            st.Push(1);
            Person person = new Person();


            Console.WriteLine(new String('=', 30));
            Console.WriteLine(arr);
            Console.WriteLine(new String('=',30));
            Console.WriteLine(st);
            Console.WriteLine(new String('=', 30));
            Console.WriteLine(person);

            Employee.GetMyFavoriteNumber();

            var emp = new Employee();

            var emp2 = new Employee2();
            emp2.ToString();

            var name1 = emp.Name;
            
            var name2 = emp2.PersonalData.Name;

        }
    }

    public class Person
    {
       public static int GetMyFavoriteNumber()
        {
            return 5;
        }
        
        public string Name { get; set; } = "Neznam";
        public string Address { get; set; } = "Neznam";
        public string PhoneNumber { get; set; } = "Neznam";
        public override string ToString()
        {
            return $"I am happy person! {Name}";
        }
    }

    public class Employee : Person
    {
        public string Company { get; set; } = "Coca Cola";
    }

    public class Employee2
    {
        public Person PersonalData { get; set; }
        public string Company { get; set; } = "Coca Cola";
    }

}
