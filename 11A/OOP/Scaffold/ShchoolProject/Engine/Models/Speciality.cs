using System;
using System.Collections.Generic;

namespace Engine.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }//5
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string GraduatesTitle { get; set; } = null!;
        public string Languages { get; set; } = null!;
        public int StartGrade { get; set; }
        public int EndGrade { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
