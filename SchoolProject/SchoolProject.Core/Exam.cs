using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        public string LessonId { get; set; }
        [Required]
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }


    }
}
