using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Repositories
{
    public interface IExamRepository
    {
        Task AddExam(Exam lesson);
        Task<IEnumerable<ExamResult>> GetExamResults();
        Task<IEnumerable<Exam>> GetExams();
    }
}
