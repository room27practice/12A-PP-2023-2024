using System;
using System.Collections.Generic;

namespace Engine.Models
{
    public partial class Class
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string GradeLetter { get; set; } = null!;
        public int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; } = null!;
    }
}
