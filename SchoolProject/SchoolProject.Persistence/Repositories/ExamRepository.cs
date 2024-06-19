using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly SchoolProjectDbContext _context;

        public ExamRepository(SchoolProjectDbContext context)
        {
            _context = context;
        }

        public async Task AddExam(Exam exam)
        {

            await _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exam>> GetExams()
        {

            return await _context.Exams.ToListAsync();
        }

        public async Task<IEnumerable<ExamResult>> GetExamResults()
        {

            IEnumerable<ExamResult> exameResults = await
                (from e in _context.Exams
                 join l in _context.Lessons on e.LessonId equals l.LessonId
                 join s in _context.Students on e.StudentId equals s.Id
                 select new { e,l,s  }).Select(x => new ExamResult
                 {
                     Id = x.e.Id,
                     Date = x.e.Date,
                     Mark = x.e.Mark,
                     StudentId = x.e.StudentId,
                     LessonId = x.e.LessonId,
                     LessonName = x.l.LessonName,
                     TeacherName = x.l.TeacherName,
                     TeacherSurname = x.l.TeacherSurname,
                     Class = x.s.Class,
                     StudentName = x.s.Name,
                     StudentSurname = x.s.Surname
                 }).ToListAsync();

            return exameResults;
        }
    }
}
