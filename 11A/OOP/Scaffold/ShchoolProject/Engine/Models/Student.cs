using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Engine.Models
{
    public partial class Student
    {
        public Student()
        { Id = Guid.NewGuid(); }

        public Student(string firstName, string lastName, string gsm, string email, string address, int age, bool gender, int classId):this()
        {
            FirstName = firstName;
            LastName = lastName;
            Gsm = gsm;
            Email = email;
            Address = address;
            Age = age;
            Gender = gender;
            ClassId = classId;
        }

        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? SurName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; } = null!;
        public string Gsm { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Age { get; set; }
        public bool Gender { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public virtual Class Class { get; set; } = null!;
    }
}
