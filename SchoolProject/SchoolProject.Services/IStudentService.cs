using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service
{
    public interface IStudentService
    {
        Task AddStudent(Student student);
        Task<IEnumerable<Student>> GetStudents();
    }
}
