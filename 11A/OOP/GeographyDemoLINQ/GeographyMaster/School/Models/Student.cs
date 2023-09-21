using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{


    public class Student : BaseEntity
    {
        [MaxLength(16), Required]
        public string FirstName { get; set; }

        [MaxLength(16)]
        public string SurnName { get; set; }

        [MaxLength(16), Required]
        public string LastName { get; set; }

        [Phone, Required]
        public string GSM { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [Range(7, 20)]
        public int Age { get; set; }
        public bool Gender { get; set; }

        public int ClassId { get; set; }

        public virtual Class Class { get; set; }

    }

}
