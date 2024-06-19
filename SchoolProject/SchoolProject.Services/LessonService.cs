using SchoolProject.Core;
using SchoolProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _repository;

        public LessonService(ILessonRepository repository)
        {
            _repository = repository;
        }

        public async Task AddLesson(Lesson lesson)
        {
          await _repository.AddLesson(lesson);
        }

        public async Task<IEnumerable<Lesson>> GetLessons()
        {
            return await _repository.GetLessons();
        }
    }
}
