using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class SchoolDBContext : DbContext
    {
        private string conString = @$"Server=localhost\SQLEXPRESS;Database=STD_DB1;Trusted_Connection=True;";

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>(s =>
            {
                s.HasIndex(e => e.GraduatesTitle).IsUnique();
            });

            modelBuilder.Entity<Class>(c =>
            {
                c.HasIndex(e => e.TeacherId).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}