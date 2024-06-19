using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.Persistence.Repositories;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Tests
{
    public class ExamRepositoryTests
    {
        [Fact]
        public async void should_add_exam()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("ShouldSaveTest")
              .Options;
            var exam = new Exam { Id = 1, StudentId = 1, LessonId = "M2", Date = new DateTime(2024,05,05) , Mark=90 };

            using var context = new SchoolProjectDbContext(dbOptions);
            var examRepository = new ExamRepository(context);
           await examRepository.AddExam(exam);

            var exams = context.Exams.ToList();
            var addedExam = Assert.Single(exams);
            Assert.Equal(exams.Count(), 1);

            Assert.Equal(addedExam.Id, exam.Id);
            Assert.Equal(addedExam.LessonId, exam.LessonId);
            Assert.Equal(addedExam.StudentId, exam.StudentId);

        }
       
        [Fact]
        public async void get_all_exams()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("GetAllTest")
            .Options;


            using var context = new SchoolProjectDbContext(dbOptions);

            context.Exams.Add(new Exam { Id = 1, StudentId = 1, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 90 });
            context.Exams.Add(new Exam { Id = 2, StudentId = 2, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 80 });
            context.SaveChanges();

            var examRepository = new ExamRepository(context);

            var exams = await examRepository.GetExams();


            Assert.Equal(2, exams.Count());
            Assert.Contains(exams, q => q.Id == 1);
            Assert.Contains(exams, q => q.Id == 2);
        }
        [Fact]
        public async void get_all_exams_empty()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("GetAllExamsEmpty")
            .Options;


            using var context = new SchoolProjectDbContext(dbOptions);


            var examRepository = new ExamRepository(context);

            var exams = await examRepository.GetExams();


            Assert.Equal(0, exams.Count());
        }

        [Fact]
        public async void get_all_exam_results()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("GetAllTestResults")
            .Options;


            using var context = new SchoolProjectDbContext(dbOptions);

            context.Exams.Add(new Exam { Id = 1, StudentId = 1, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 90 });
            context.Exams.Add(new Exam { Id = 2, StudentId = 2, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 80 });
            context.Lessons.Add(new Lesson { LessonId = "M1", Class = 1, LessonName = "Math1", TeacherName = "ABC", TeacherSurname = "DFG" });
            context.Lessons.Add(new Lesson { LessonId = "M2", Class = 1, LessonName = "Math2", TeacherName = "ABC", TeacherSurname = "DFG" });
            context.Students.Add(new Student { Id = 1, Class = 1, Name = "Mike", Surname = "ABC" });
            context.Students.Add(new Student { Id = 2, Class = 1, Name = "Math2", Surname = "ABC" });
            context.SaveChanges();

            var examRepository = new ExamRepository(context);

            var exams = await examRepository.GetExamResults();


            Assert.Equal(2, exams.Count());

            Assert.Contains(exams, q => q.Id == 1);
            Assert.Contains(exams, q => q.LessonId == "M2");
            Assert.DoesNotContain(exams, q => q.LessonId =="M1");
            Assert.Contains(exams, q => q.StudentId == 1);
            Assert.Contains(exams, q => q.StudentId == 2);
            Assert.Contains(exams, q => q.StudentName =="Mike");
            Assert.Contains(exams, q => q.LessonName =="Math2");



            Assert.Contains(exams, q => q.Id == 2);
        }

        [Fact]
        public async void get_all_exam_results_no_successfull_join()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("GetAllTestResultsNoSuccess")
            .Options;


            using var context = new SchoolProjectDbContext(dbOptions);

            context.Exams.Add(new Exam { Id = 1, StudentId = 1, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 90 });
            context.Exams.Add(new Exam { Id = 2, StudentId = 2, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 80 });
            context.Lessons.Add(new Lesson { LessonId = "M1", Class = 1, LessonName = "Math1", TeacherName = "ABC", TeacherSurname = "DFG" });
            context.Students.Add(new Student { Id = 1, Class = 1, Name = "Mike", Surname = "ABC" });
            context.SaveChanges();

            var examRepository = new ExamRepository(context);

            var exams = await examRepository.GetExamResults();


            Assert.Equal(0, exams.Count());



        }

        [Fact]
        public async void get_all_exam_results_empty()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("GetAllTestEmpty")
            .Options;


            using var context = new SchoolProjectDbContext(dbOptions);


            var examRepository = new ExamRepository(context);

            var exams = await examRepository.GetExamResults();

            Assert.Equal(0, exams.Count());

        }

    }
}
