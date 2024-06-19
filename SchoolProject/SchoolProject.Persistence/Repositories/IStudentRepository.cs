using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task<IEnumerable<Student>> GetStudents();
    }
}
