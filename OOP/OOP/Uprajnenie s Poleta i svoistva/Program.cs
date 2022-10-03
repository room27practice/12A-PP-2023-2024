using System;
using System.Linq;

namespace Uprajnenie_s_Poleta_i_svoistva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Id = "asdas-dsf-asdas-dasd";
            p1.FirstName = "Ivan";
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

            var t1 = new Town(1, "Shumen", 85000, "9700",c1);
            var t2 = new Town(2, "Varna", 225000, "1700");
            t1.Region = t2;           
            t2.Country = c1;
            p1.Town = t1;

            var p2 = new Person
            {
                Id = "213dsaf-23$23@@-54",
                FirstName = "Mihaela",
                LastName = "Valentinova",
                Age = 16,
                Gender = false,
                Email = "vali@gmail.com",
                Town=t2
            };

            Person[] people = new Person[] { p1, p2 };
        }


        public static int CalcNumbers(int a, int b)
        {
            return a + b;
        }
    }


    public class Person
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public Town Town { get; set; }
    }

    public class Town
    {
        public Town(int id, string name, int population, string postCode)
        {
            Id = id;
            Name = name;
            Population = population;
            PostCode = postCode; 
        }


        public Town(int id, string name, int population, string postCode,Country country)
        {
            Id = id;
            Name = name;
            Population = population;
            PostCode = postCode;
            Country = country;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string PostCode { get; set; }
        public Country Country { get; set; }
        public Town Region { get; set; }
    }

    public class Country
    {
        private string designation;

        public int Id { get; set; }
        public string Name { get; set; }
        public double PopulationInMilions { get; set; }
        public string Designation
        {
            get
            {

                return designation;
            }

            set
            {
                bool lenghtTooMuch = value.Length > 2;
                bool nonLettersUsed = value.Any(x => !Char.IsLetter(x));
                if (lenghtTooMuch)
                {
                    Console.WriteLine("Incorrect Data. Designation must be exactly 2 symbols long!");
                }
                if (nonLettersUsed)
                {
                    Console.WriteLine("Incorrect Data. Only letters must be used!");
                }
                if (!lenghtTooMuch && !nonLettersUsed)
                {
                    designation = value.ToUpper();
                }
            }
        }


        public string ContinentName { get; set; }
        public string Languages { get; set; }
        public string Description { get; set; }
    }
}
