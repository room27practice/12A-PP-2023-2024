using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprajnenie_s_Poleta_i_svoistva
{
    public class Person
    {
        public static string SchoolName { get; set; } = "PGMETT";
       
        public  static void SaySchoolName()
        {
            Console.WriteLine($"The school name is {SchoolName}");
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public int Age { get;  set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public Town Town { get; set; }

        public string PresentYourself()
        {
            return $@"I am {(Gender ? "mr" : "ms")} {Name} {LastName}.
I am {Age} old.{(Town != null ? "I live in " + Town.Name : "I don't live in town")}.";
        }

        public void GetOlder(int years)
        {
            Age += (years < 0) ? -years : years;
        }

    }
}
