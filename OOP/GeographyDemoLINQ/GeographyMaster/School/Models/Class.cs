using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    //    Classes:


    public class Class : BaseEntity
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        [Range(1, 12)]
        public int Grade { get; set; }
        public char GradeLetter { get; set; }

        [ForeignKey(nameof(Speciality))]
        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }


        public ICollection<Student> Students { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher KlasenRukovoditel { get; set; }

    }

}
