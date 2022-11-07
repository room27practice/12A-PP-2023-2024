// See https://aka.ms/new-console-template for more information
using Engine.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

Console.WriteLine("Hello, World!");




using (var db = new SchoolDBContext())
{

    Student[] students = db.Students
       .Include(x => x.Class)
        // .Where(s=>s.Class.Speciality.Name=="Programirane")
        // .Where(s => s.FirstName.StartsWith("N"))
        .ToArray();


    var newStudent = new Student("Azis", "Habibi", "98342342346546", "vasko@jabata", "sofia tri ushi", 24, false, 2);
    db.Students.Add(newStudent);
  
    db.SaveChanges();
    foreach (var stdnt in students)
    {
        Console.WriteLine(stdnt.Email);
    }
    db.Dispose();


}







var something = Console.ReadLine();