using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Models
{
    public partial class Teacher
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Gender { get; set; }
        public string Email { get; set; } = null!;
        public string? Subjects { get; set; }
        
        [ForeignKey("Class")]
        public int? ManagedClassId { get; set; }
        public virtual Class? ManagedClass { get; set; }
    }
}
