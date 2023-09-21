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

        Class clas = new Class()
        {
            Grade = 11,
            GradeLetter = 'A',
            //KlasenRukovoditel
            //Speciality

        };


        using (var db = new SchoolDBContext())
        {
            var teacherFd = db.Teachers.Where(x => !x.IsDeleted).FirstOrDefault(x => x.LastName == "Hristov");
            var specialityFd = db.Specialities.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Name.StartsWith("Prog"));
            if (teacherFd==null||specialityFd==null)
            {
                throw new ArgumentException("Not found Entity!!!!");
            }
            clas.KlasenRukovoditel = teacherFd;

            clas.SpecialityId = specialityFd.Id;

            clas.Students.Add(new Student()
            {
                FirstName = "Ibrahim",
                LastName = "Ibrahimovich",
                SurnName = "Zlatan",
                Age = 20,
                Email = "jelezar@gmail.com",
                Gender = true,
                GSM = "+359765688898",
            });
            db.Add(clas);

            // db.AddRange(specialities);


            //   db.Add(teacher1);
            db.SaveChanges();
        }









    }
}

