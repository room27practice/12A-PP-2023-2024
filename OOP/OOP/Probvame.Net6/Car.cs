namespace Probvame.Net6
{
    internal class Car
    {
        public Car()
        {
            YearOfMake = 1989;            
        }
        internal Car(string color) : this()
        {
            Color = color;
        }
        internal Car(double weight, string color) : this(color)
        {
            //YearOfMake = 1989;
            //Color = color;
            Weight = weight;
        }

        internal Car(double weight) : this()
        {
            Weight = weight;
            YearOfMake = 10;
        }
        public int YearOfMake { get; } = 20;
        public double Weight { get; set; }
        public string Color { get; set; } = "Yellow";
        public void StartEngine()
        {
            Console.WriteLine(Sum(2, 4));
            Console.WriteLine(Sum('t', 4));
        }
        public static int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        public static int Sum(char n1, int n2)
        {
            return n1 + n2;
        }

        public int Sum(int n1, int n2, int n3)
        {
            return Sum(Sum(n1, n2), n3);
        }
    }
}
