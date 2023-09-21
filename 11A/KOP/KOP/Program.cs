using System.Diagnostics;

namespace KOP
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("CPUS: " + Environment.ProcessorCount);
            Thread.Sleep(5000);
            
            Stopwatch watch = new Stopwatch();
            watch.Start();
            PrintEvenNumbers(100000);
            watch.Stop();
            var time1 = watch.Elapsed;
            
            watch.Restart();
            PrintEvenNumbersBetter(100000);
            watch.Stop();
            var time2 = watch.Elapsed;
           
            
            Console.WriteLine($"First Method was done for {time1.Ticks}");
            Thread.Sleep(2000);
            Console.WriteLine($"Secod Method was done for {time2.Ticks}");
            Thread.Sleep(2000);
            Console.WriteLine($"Better Method was  {(100*(decimal)time1.Ticks/ (decimal)time2.Ticks-100):F2}% faster");

        }


        public static void PrintEvenNumbers(int maxNumber = 100)
        {
            for (int i = 0; i <= maxNumber; i++)
            {
                if (i % 2 == 0)
                {
                    if (i>6&& i%3==0||i==9)
                    {
                    }
                    Console.WriteLine(i);
                }               
            }
        }


        public static void PrintEvenNumbersBetter(int maxNumber = 100)
        {
            for (int i = 0; i <= maxNumber; i+=2)
            {              
                    Console.WriteLine(i); 
            }
        }


    }





}