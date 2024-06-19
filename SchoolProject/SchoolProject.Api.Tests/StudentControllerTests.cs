using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolProject.Api.Controllers;
using SchoolProject.Core;
using SchoolProject.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Api.Tests
{
    public class StudentControllerTests
    {
        private Mock<IStudentService> _studentService;
        private StudentController _controller;

        public StudentControllerTests()
        {
            _studentService = new Mock<IStudentService>();
            _controller=new StudentController( _studentService.Object );
        }

        [Fact]
        public async void add_student_model_state_error()
        {
            var _request = new Core.Student {  Class=1 };
            _controller.ModelState.AddModelError("Key", "ErrorMessage");

            var result = await _controller.AddStudent(_request);

            result.ShouldBeOfType(typeof(BadRequestObjectResult));
            _studentService.Verify(x => x.AddStudent(_request), Times.Exactly(0));

        }

        [Fact]
        public async void add_student_throws_exception()
        {
            var _request = new Core.Student { Class = 1 };
            _studentService.Setup(x => x.AddStudent(_request)).Throws<Exception>();

            var result = await _controller.AddStudent(_request);

            result.ShouldBeOfType(typeof(StatusCodeResult));

            _studentService.Verify(x => x.AddStudent(_request), Times.Exactly(1));

        }

        [Fact]
        public async void add_student_success()
        {
            var _request = new Core.Student { Class = 1 };

            var result = await _controller.AddStudent(_request);

            result.ShouldBeOfType(typeof(OkObjectResult));

            _studentService.Verify(x => x.AddStudent(_request), Times.Exactly(1));

        }
        [Fact]
        public async void get_students_throws_exception()
        {
            _studentService.Setup(x => x.GetStudents()).Throws<Exception>();

            var result = await _controller.GetStudents();

            result.ShouldBeOfType(typeof(StatusCodeResult));

            _studentService.Verify(x => x.GetStudents(), Times.Exactly(1));

        }
        [Fact]
        public async void get_students_success()
        {
            var _result = new List<Student>
            {
              new Student { Id = 1, Class = 1, Name = "Math1", Surname = "ABC" }
            };

            _studentService.Setup(x => x.GetStudents()).ReturnsAsync(_result);

            var result = await _controller.GetStudents();



            result.ShouldBeOfType(typeof(OkObjectResult));
            _studentService.Verify(x => x.GetStudents(), Times.Exactly(1));


        }
    }
}
