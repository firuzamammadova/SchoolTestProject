using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolProjectDbContext _context;

        public StudentRepository(SchoolProjectDbContext context)
        {
            _context = context;
        }

        public async Task AddStudent(Student student)
        {

           await _context.Students.AddAsync(student);
          await  _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {

            return await _context.Students.ToListAsync() ;
        }
    }
}
