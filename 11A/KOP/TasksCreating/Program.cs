using System.Runtime.InteropServices;
using System.Threading;

namespace TasksCreating
{
    internal class Program
    {
        static void Main()
        {
            Task<string>[] grils = new Task<string>[4];
            for (int i = 0; i < 4; i++)
            {
                grils[i] = MakeBurgerAsync(4 - i);
            }

            while (true)
            {
                Console.Write("Write request: ");
                string request = Console.ReadLine();

                if (request.ToLower() == "end")
                {
                    Console.WriteLine("Requests ended");
                    break;
                }
                Console.WriteLine($"You requested more {request}");
            }

            while (true)
            {
                Console.WriteLine(new string('=', 30));
                if (!grils.Any(x => x.Status == TaskStatus.Running))
                {
                    Console.WriteLine("All tasks are done!");
                    break;
                }

                for (int i = 0; i < grils.Length; i++)
                {
                    if (grils[i].Status == TaskStatus.Running)
                    {
                        Console.WriteLine($"Task N{i + 1} is still running");
                    }
                }
                Console.WriteLine(new string('=', 30));
                Thread.Sleep(1000);
            }
            // getFood.Wait();
            Console.WriteLine("Program ended");


        }

        static Task<string> MakeBurgerAsync(int timeSeconds)
        {
            Task<string> getFood = new Task<string>(() => MakeBurger(timeSeconds));
            getFood.Start();
            return getFood;
        }

        static string MakeBurger(int timeSeconds)
        {
            var actions = new string[] { "Bake burger buns", "Grill patty", "Apply lettuce, tomatoes, onion and Patty", "Add sauses..", "Serve in plate" };
            string text = "";

            for (int i = 0; i < actions.Length; i++)
            {
                Thread.Sleep(timeSeconds * 1000);
                Console.WriteLine($"Step {i + 1}: {actions[i]}");

                text += $" Step {i + 1}: {actions[i]}";
            }
            var text2 = text.ToCharArray();
            Array.Reverse(text2);
            return string.Join("", text2.Select(x => x.ToString()));


        }
    }
}