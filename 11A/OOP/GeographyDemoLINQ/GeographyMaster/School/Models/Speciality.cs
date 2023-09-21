using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    //    Speciality:
    //Id - int
    //Name -  текст до 16 символа задължително и уникално
    //Description - текст до 1024 символа.
    //GraduatesTitle- текст до 32 символа задължително и уникално описва как се именоват завършилите дадената специалност например “Приложен програмист”
    //StartGrade - число в интервала 1-12 задължително
    //EndGrade - число в интервала 1-12 задължително
    public class Speciality : BaseEntity
    {
        public Speciality()
        {
            Classes = new HashSet<Class>();
        }

        public Speciality(string name, string description, string graduatesTitle)
        {
            Name = name;
            Description = description;
            GraduatesTitle = graduatesTitle;
            StartGrade = 8;
            EndGrade = 12;

        }

        public Speciality(string name, string description, string graduatesTitle,int startGrade,int endGrade):this(name,description,graduatesTitle)
        {
            StartGrade = startGrade;
            EndGrade = endGrade;
        }



        public string Name { get; set; }
        public string Description { get; set; }

        //TODO UNIQUE
        [MaxLength(32),Required]
        public string GraduatesTitle { get; set; }

        [Range(1,12)]
        public int StartGrade { get; set; }
        [Range(1, 12)]
        public int EndGrade { get; set; } 

        public virtual ICollection<Class> Classes { get; set; }

    }

}
