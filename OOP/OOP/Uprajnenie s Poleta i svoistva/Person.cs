using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uprajnenie_s_Poleta_i_svoistva
{
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

        public string PresentYourself()
        {
            string mestoimenie = Gender ? "mr" : "ms";
            return $@"I am {mestoimenie} {FirstName} {LastName}. 
                        And I am {Age} old.{(Town != null ? "I live in " + Town.Name : "I don't live in town")}.";

        }
    }
}
