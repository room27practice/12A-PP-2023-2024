using System;
namespace Uprajnenie_s_Poleta_i_svoistva
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Id = "asdas-dsf-asdas-dasd";
            p1.Name = "Ivan";
            p1.SurName = "Sur Sur";
            p1.LastName = "Ivanov";
            p1.Age = 12;
            p1.Gender = true;
            p1.Email = "babajaba@abv.bg";


            var c1 = new Country
            {
                Id = 1,
                Name = "Bulgaria",
                Description = "Visoki Sini Planini, Reki i zlatni ravnini....",
                Designation = "BG",
                PopulationInMilions = 6.5,
                ContinentName = "Europa",
                Languages = "Bulgarian",
            };

            var t1 = new Town(1, "Shumen", 85000, "9700", c1);
            var t2 = new Town(2, "Varna", 225000, "1700");
            t1.Region = t2;
            t2.Country = c1;
            p1.Town = t1;

            var p2 = new Person
            {
                Id = "213dsaf-23$23@@-54",
                Name = "Mihaela",
                LastName = "Valentinova",
                Age = 16,
                Gender = false,
                Email = "vali@gmail.com",
                Town = t2
            };

            Person[] people = new Person[] { p1, p2,
                new Person {
                              Id = "pncfgsht444-34sdaf-42342",
                              Name = "Slavena",
                              SurName = "Miroslavova",
                              LastName = "Krasimirova",
                              Age = 15,
                              Gender = false,
                              Email = "slavena@yahoo.com",
                              Town = t2
                           },
                                };
            people[2].SurName = "Georgieva";
            Console.WriteLine(p1.PresentYourself());
            p1.GetOlder(5);
            Console.WriteLine(new string('=', 30));
            foreach (var person in people)
            {
                Console.WriteLine(person.PresentYourself());
            }

            Console.WriteLine(Person.SchoolName);
            //  Person.SchoolName = "Hristo Botev";
            Console.WriteLine(Person.SchoolName);

            Person.SaySchoolName();

            var number0 = HelperStatic.MakeDouble("6.54");
            var number1 = HelperStatic.MakeDouble("6.54");
            var number2 = HelperStatic.MakeDouble("6.54");
            var number3 = HelperStatic.MakeDouble("6.54");
            var number4 = HelperStatic.MakeDouble("6.54");
            var number5 = HelperStatic.MakeDouble("6.54");

        }


        public static int CalcNumbers(int a, int b)
        {
            return a + b;
        }
    }
}
