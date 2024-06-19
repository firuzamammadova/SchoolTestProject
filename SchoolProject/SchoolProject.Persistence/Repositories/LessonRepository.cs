using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly SchoolProjectDbContext _context;

        public LessonRepository(SchoolProjectDbContext context)
        {
            _context = context;
        }
        public async Task AddLesson(Lesson lesson)
        {

          await _context.Lessons.AddAsync(lesson);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessons()
        {
           return await _context.Lessons.ToListAsync();
        }
    }
}
