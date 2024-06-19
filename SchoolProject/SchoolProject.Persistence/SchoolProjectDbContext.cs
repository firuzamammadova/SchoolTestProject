using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SchoolProject.Persistence
{
    public class SchoolProjectDbContext : DbContext
    {
        public SchoolProjectDbContext(DbContextOptions<SchoolProjectDbContext> options) : base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.LessonName).HasMaxLength(30);
            modelBuilder.Entity<Lesson>()
             .Property(e => e.TeacherName).HasMaxLength(20);
            modelBuilder.Entity<Lesson>()
             .Property(e => e.TeacherSurname).HasMaxLength(20);

            modelBuilder.Entity<Lesson>()
             .Property(e => e.LessonId).HasColumnType("char").HasMaxLength(3).IsFixedLength();

            modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(30);
            modelBuilder.Entity<Student>().Property(e => e.Surname).HasMaxLength(30);
            modelBuilder.Entity<Exam>().HasKey("Id");


            modelBuilder.Entity<Exam>()
                .Property(e => e.LessonId).HasColumnType("char").HasMaxLength(3).IsFixedLength();
            modelBuilder.Entity<Exam>()
              .Property(e => e.StudentId).IsRequired();
            modelBuilder.Entity<Lesson>().HasData(
                new Lesson { LessonId = "M1", Class = 1, LessonName = "Math", TeacherName = "ABC", TeacherSurname = "DFG" },
                new Lesson { LessonId = "G1", Class = 1, LessonName = "Geometry", TeacherName = "ABC", TeacherSurname = "DFG" });


            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Class = 1, Name = "Meredith", Surname = "Grey" },
                new Student { Id = 2, Class = 1, Name = "Christina", Surname = "Yang",});
            modelBuilder.Entity<Exam>().HasData(
                new Exam { Id=1, StudentId = 1, LessonId = "M1", Date = new DateTime(2024, 05, 06), Mark = 99 },
                new Exam { Id = 2, StudentId = 2, LessonId = "M1", Date = new DateTime(2024, 05, 06), Mark = 95 },
                new Exam { Id = 3, StudentId = 2, LessonId = "G1", Date = new DateTime(2024, 05, 10), Mark = 91 },
                new Exam { Id = 4, StudentId = 1, LessonId = "G1", Date = new DateTime(2024, 05, 10), Mark = 100 }
                );
        }
    }
}
