using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Teacher : BaseEntity
    {
        [MaxLength(16), Required]
        public string FirstName { get; set; } 
        [MaxLength(16), Required]
        public string LastName { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [EmailAddress, Required]
        public bool Gender { get; set; }
        
        [MaxLength(64)]
        public string Subjects { get; set; }

        //[ForeignKey(nameof(Class))]
        //public int? ManagedClassID { get; set; }
        //public virtual Class ManagedClass { get; set; }
    }

}
