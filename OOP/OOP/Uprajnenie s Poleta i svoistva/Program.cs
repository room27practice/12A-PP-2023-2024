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

            var t1 = new Town(1, "Shumen", 85000, "9700", c1);
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
                Town = t2
            };

            Person[] people = new Person[] { p1, p2 };
        }


        public static int CalcNumbers(int a, int b)
        {
            return a + b;
        }
    }
}
