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
    public class LessonControllerTests
    {
        private Mock<ILessonService> _lessonService;
        private LessonController _controller;

        public LessonControllerTests()
        {
            _lessonService = new Mock<ILessonService>();
            _controller = new LessonController(_lessonService.Object);
        }

        [Fact]
        public async void add_lesson_model_state_error()
        {
            var _request =  new Lesson { Class=1 };
            _controller.ModelState.AddModelError("Key", "ErrorMessage");

            var result = await _controller.AddLesson(_request);

            result.ShouldBeOfType(typeof(BadRequestObjectResult));
            _lessonService.Verify(x => x.AddLesson(_request), Times.Exactly(0));

        }

        [Fact]
        public async void add_lesson_throws_exception()
        {
            var _request = new Lesson { Class = 1 };
            _lessonService.Setup(x => x.AddLesson(_request)).Throws<Exception>();

            var result = await _controller.AddLesson(_request);

            result.ShouldBeOfType(typeof(StatusCodeResult));

            _lessonService.Verify(x => x.AddLesson(_request), Times.Exactly(1));

        }

        [Fact]
        public async void add_lesson_success()
        {
            var _request = new Lesson { Class = 1 };

            var result = await _controller.AddLesson(_request);

            result.ShouldBeOfType(typeof(OkObjectResult));

            _lessonService.Verify(x => x.AddLesson(_request), Times.Exactly(1));

        }
        [Fact]
        public async void get_lessons_throws_exception()
        {
            _lessonService.Setup(x => x.GetLessons()).Throws<Exception>();

            var result = await _controller.GetLessons();

            result.ShouldBeOfType(typeof(StatusCodeResult));

            _lessonService.Verify(x => x.GetLessons(), Times.Exactly(1));

        }
        [Fact]
        public async void get_lessons_success()
        {
            var _result = new List<Lesson>
            {
             new Lesson { Class = 1 }
        };

            _lessonService.Setup(x => x.GetLessons()).ReturnsAsync(_result);

            var result = await _controller.GetLessons();



            result.ShouldBeOfType(typeof(OkObjectResult));
            _lessonService.Verify(x => x.GetLessons(), Times.Exactly(1));


        }
    }
}
