using SchoolProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public class ExamResult
    {
        public int Id { get; set; }
        public string LessonId { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int Class { get; set; }

        public string LessonName { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    }
}