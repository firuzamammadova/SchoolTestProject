using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Tests
{
    public class StudentRepositoryTests
    {
        [Fact]
        public async void should_add_student()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("ShouldSaveTest")
              .Options;
            var student = new Student { Id = 1, Class = 1, Name = "Math2", Surname = "ABC" };

            using var context = new SchoolProjectDbContext(dbOptions);
            var studentRepository = new StudentRepository(context);
           await studentRepository.AddStudent(student);

            var students = context.Students.ToList();
            var addedStudent = Assert.Single(students);
            Assert.Equal(students.Count(), 1);

            Assert.Equal(addedStudent.Id, student.Id);
            Assert.Equal(addedStudent.Name, student.Name);
        }
        [Fact]
        public async void get_all_students()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("GetAllTest")
            .Options;


            using var context = new SchoolProjectDbContext(dbOptions);

            context.Students.Add(new Student { Id = 1, Class = 1, Name = "Math1", Surname = "ABC" });
            context.Students.Add(new Student { Id = 2, Class = 1, Name = "Math2", Surname = "ABC" });
            context.SaveChanges();

            var studentRepository = new StudentRepository(context);

            var students = await studentRepository.GetStudents();


            Assert.Equal(2, students.Count());
            Assert.Contains(students, q => q.Id == 1);
            Assert.Contains(students, q => q.Id == 2);
        }
    }
}
