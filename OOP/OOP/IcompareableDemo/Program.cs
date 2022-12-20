namespace IcompareableDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharDemo();
        }

        private static void CharDemo()
        {
            Console.WriteLine(new string((char)181,10));
            
            
            string message = "Hello, World!";

            foreach (var letter in message)
            {
                Console.WriteLine((int)letter + " " + letter);
            }
            Console.WriteLine(new string('=', 20));
            if ('z' - 'a' > 0)
            {
                Console.WriteLine('z' - 'a');
            }


        }




    }

}