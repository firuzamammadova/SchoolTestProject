using SchoolProject.Core;
using SchoolProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;

        public ExamService(IExamRepository repository)
        {
            _repository = repository;
        }

        public async Task AddExam(Exam exam)
        {
           await _repository.AddExam(exam);
        }

        public async Task<IEnumerable<ExamResult>> GetExamResults()
        {
            return await _repository.GetExamResults();
        }

        public async Task<IEnumerable<Exam>> GetExams()
        {
            return await _repository.GetExams();
        }
    }
}
