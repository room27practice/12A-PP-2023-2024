using School.Models;

public class Program
{
    public static void Main()
    {

        List<Speciality> specialities = new List<Speciality>()

        {
            new Speciality("Programirane","Mnogo kod se pishe v tazi specialnost","Programist"),
            new Speciality("Dvigateli","Mnogo brumchat","Avtomontior"),
            new Speciality("Ikonomika","Smetki smetki schetovodstvo","Finansist"),
            new Speciality("Kompiuturna tehnika","zapoqvame shtepseli","Tehnik na Kompiutri"),
         };

        var teacher1 = new Teacher()
        {
            FirstName = "Nikolay",
            LastName = "Hristov",
            Email = "alabala@abv.bg",
            Gender = true,
            Subjects = "KOP MOP OOP WEB",
        };

        using (var db = new SchoolDBContext())
        {
            // db.AddRange(specialities);

            db.Add(teacher1);
            db.SaveChanges();
        }









    }
}

