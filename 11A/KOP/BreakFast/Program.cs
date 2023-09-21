namespace BreakFast
{
    internal class Program
    {
        static  void Main()
        {
            



            if(Thread.CurrentThread.ThreadState == ThreadState.Running)
            {
                Console.WriteLine($"Main ThreadId is : {Thread.CurrentThread.ManagedThreadId}");

            }
            Task coffee = new Task(() => PourCoffee());
            Task fryThings = new Task(() =>
            {
                HeatPan();
                FryEggs();
                FryBacon();
            });
            Task prepareBread = new Task(() =>
            {
                if (Thread.CurrentThread.ThreadState != ThreadState.Running)
                {
                    Console.WriteLine($"Bread ThreadId is : {Thread.CurrentThread.ManagedThreadId}");

                }
                ToastBread();
                JamOnBread();
            });

            Task juice = new Task(() => PourJuiceInGlass());

            Task[] breakfast = { coffee, fryThings, prepareBread, juice };
            for (int i = 0; i < breakfast.Length; i++)
            {
                breakfast[i].Start();
            }
           Thread.Sleep(4000);
            //Task.WaitAll(breakfast);
            Console.WriteLine("BreakFast was done");

            //PourCoffee();
            //HeatPan();
            //FryEggs();
            //FryBacon();

            //ToastBread();
            //JamOnBread();

            //PourJuiceInGlass();

        }

        public static void PourCoffee()
        {
            Thread.Sleep(2500);
            Console.WriteLine("1. The Cofee was Poured.");
        }

        public static void HeatPan()
        {
            Thread.Sleep(3000);
            Console.WriteLine("2. The Pan Was Heated.");
        }
        public static void FryEggs()
        {
            Thread.Sleep(5000);
            Console.WriteLine("3. Eggs were fried.");
        }

        public static void FryBacon()
        {
            Thread.Sleep(6000);
            Console.WriteLine("4. Bacon was roasted.");
        }

        public static void ToastBread()
        {
            Thread.Sleep(3000);
            Console.WriteLine("5. The Bread was toasted.");
        }

        public static void JamOnBread()
        {
            Thread.Sleep(1000);
            Console.WriteLine("5. Spreaded Jam on slices of bread.");
        }

        public static void PourJuiceInGlass()
        {
            Thread.Sleep(3500);
            Console.WriteLine("6. Poured Jouce in glass");
        }

    }
}