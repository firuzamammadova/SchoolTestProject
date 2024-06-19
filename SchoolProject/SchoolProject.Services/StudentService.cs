using SchoolProject.Core;
using SchoolProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddStudent(Student student)
        {

          await  _repository.AddStudent(student);
        }

        public Task<IEnumerable<Student>> GetStudents()
        {
            return _repository.GetStudents();
        }
    }
}
