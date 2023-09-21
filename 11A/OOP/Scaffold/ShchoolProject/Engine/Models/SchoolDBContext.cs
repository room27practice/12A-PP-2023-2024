using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Engine.Models
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-H86OA8E\\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.GradeLetter)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialityId).HasColumnName("SpecialityID");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SpecialityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Speciality");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("Speciality");

                entity.HasIndex(e => e.Name, "UQ__Speciali__737584F62CD741E0")
                    .IsUnique();

                entity.HasIndex(e => e.GraduatesTitle, "UQ__Speciali__A34930846AECFECC")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.GraduatesTitle)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Languages)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Email, "UQ__Students__A9D10534C21D1125")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Email).HasMaxLength(32);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("GSM");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.SurName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Classes");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.Email, "UQ__Teachers__A9D105343907F42C")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(32);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ManagedClassId).HasColumnName("ManagedClassID");

                entity.Property(e => e.Subjects)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.ManagedClass)
                    .WithMany()
                    .HasForeignKey(d => d.ManagedClassId)
                    .HasConstraintName("FK_Teacher_Class");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
