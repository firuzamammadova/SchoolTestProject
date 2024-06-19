using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Repositories
{
    public interface ILessonRepository
    {
        Task AddLesson(Lesson lesson);
        Task<IEnumerable<Lesson>> GetLessons();


    }
}
