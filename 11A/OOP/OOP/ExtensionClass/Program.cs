namespace ExtensionClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// double number = double.Parse("6,543");

            string something = "123.5";
            double sdouble = something.To<double>();
          //  int sint= something.To<int>();
          //  long slong= something.To<long>();
            float sfloat= something.To<float>();
            decimal sdecimal = something.To<decimal>();

            string test2 = "true";
            bool iskamBoolean = test2.To<bool>();

            string test3 = "t";
            char iskamChar = test3.To<char>();


            string[] spisuk =  {"a", "b", "s", "u", "t","u","i","t","g", "k", "a","d"," ","s","b","U","e" };


            var evens = spisuk.GetEvens();
            Console.WriteLine(string.Join("",evens));

            while (true)
            {
                Console.Write("Napishi chislo: ");
                string input = Console.ReadLine();
                if (input == "End")
                {
                    continue;

                }
                double? num1 = input.ToDouble();

                // double num1 = Console.ReadLine().ToDouble();
                Console.WriteLine("The secret code number is: " + num1);

            }


            //double num2 = "alabala".ToDouble();



            var p = new Person()
            {
                Name = "Osman",
                Age = 37
            };

            //var p1 = new MyPerson();

            Console.WriteLine(p.SumOfNumbersAndAge(1, 10)); ;

            // Console.WriteLine(LINQQ.SumOfNumbers(54,5);
        }
    }

    public class Person
    {
        private string egn = "aj23332";
        public int Age { get; set; }
        public string Name { get; set; }



        public void SayHello()
        {
            return;
            Console.WriteLine($"I am {this.Name}. And I am {this.Age} years old");
        }

    }

    public class MyPerson : Person
    {

    }



}