using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.Persistence.Repositories;

namespace SchoolProject.Persistence.Tests
{
    public class LessonRepositoryTests
    {
        [Fact]
        public async void should_add_lesson()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("ShouldSaveTest")
              .Options;
            var lesson = new Lesson { LessonId = "M4", Class = 1, LessonName = "Math2", TeacherName = "ABC", TeacherSurname = "DFG" };

            using var context = new SchoolProjectDbContext(dbOptions);
            var lessonRepository = new LessonRepository(context);
          await  lessonRepository.AddLesson(lesson);

            var lessons = context.Lessons.ToList();
            var addedLesson = Assert.Single(lessons);
            Assert.Equal(lessons.Count(), 1);

            Assert.Equal(addedLesson.LessonId, lesson.LessonId);
            Assert.Equal(addedLesson.LessonName, lesson.LessonName);
        }
        [Fact]
        public async void get_all_lessons()
        {
            var dbOptions = new DbContextOptionsBuilder<SchoolProjectDbContext>().UseInMemoryDatabase("GetAllTest")
            .Options;


            using var context = new SchoolProjectDbContext(dbOptions);

            context.Lessons.Add(new Lesson { LessonId = "M1", Class = 1, LessonName = "Math1", TeacherName = "ABC", TeacherSurname = "DFG" });
            context.Lessons.Add(new Lesson { LessonId = "M2", Class = 1, LessonName = "Math2", TeacherName = "ABC", TeacherSurname = "DFG" });
            context.Lessons.Add(new Lesson { LessonId = "M3", Class = 2, LessonName = "Math3", TeacherName = "ABC", TeacherSurname = "DFG" });
            context.SaveChanges();

            var lessonRepository = new LessonRepository(context);

            var lessons= await lessonRepository.GetLessons();


            Assert.Equal(3, lessons.Count());
            Assert.Contains(lessons, q => q.LessonId == "M3");
            Assert.Contains(lessons, q => q.LessonId == "M2");
            Assert.DoesNotContain(lessons, q => q.LessonId == "M5");
        }
    }
}