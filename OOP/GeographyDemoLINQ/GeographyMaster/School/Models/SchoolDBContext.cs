using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class SchoolDBContext:DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Student> Students { get; set; }






    }
}
