using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolProject.Api.Controllers;
using SchoolProject.Core;
using SchoolProject.Service;
using Shouldly;

namespace SchoolProject.Api.Tests
{
    public class ExamControllerTests
    {
        private Mock<IExamService> _examService;
        private ExamController _controller;

        public ExamControllerTests()
        {
            _examService = new Mock<IExamService>();
            _controller = new ExamController(_examService.Object);
        }

        [Fact]
        public async void add_exam_model_state_error()
        {
            var _request = new Core.Exam { Date = DateTime.Now };
            _controller.ModelState.AddModelError("Key", "ErrorMessage");

            var result = await _controller.AddExam(_request);

            result.ShouldBeOfType(typeof(BadRequestObjectResult));
            _examService.Verify(x => x.AddExam(_request), Times.Exactly(0));

        }
        [Fact]
        public async void add_exam_throws_exception()
        {
            var _request = new Core.Exam { Date = DateTime.Now };
            _examService.Setup(x => x.AddExam(_request)).Throws<Exception>();

            var result = await _controller.AddExam(_request);

            result.ShouldBeOfType(typeof(StatusCodeResult));

            _examService.Verify(x => x.AddExam(_request), Times.Exactly(1));

        }

        [Fact]
        public async void add_exam_success()
        {
            var _request = new Core.Exam { Date = DateTime.Now };

            var result = await _controller.AddExam(_request);

            result.ShouldBeOfType(typeof(OkObjectResult));

            _examService.Verify(x => x.AddExam(_request), Times.Exactly(1));

        }


        [Fact]
        public async void get_exams_throws_exception()
        {
            _examService.Setup(x => x.GetExams()).Throws<Exception>();

            var result = await _controller.GetExams();

            result.ShouldBeOfType(typeof(StatusCodeResult));

            _examService.Verify(x => x.GetExams(), Times.Exactly(1));

        }
        [Fact]
        public async void get_exams_success()
        {
            var _result = new List<Exam>
            {
                new Exam { Id = 1, StudentId = 1, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 90 },
                new Exam { Id = 2, StudentId = 2, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 90 }
            };

            _examService.Setup(x => x.GetExams()).ReturnsAsync(_result);

            var result = await _controller.GetExams();



            result.ShouldBeOfType(typeof(OkObjectResult));
            _examService.Verify(x => x.GetExams(), Times.Exactly(1));


        }
        [Fact]
        public async void get_exam_results_throws_exception()
        {
            _examService.Setup(x => x.GetExamResults()).Throws<Exception>();

            var result = await _controller.GetExamResults();

            result.ShouldBeOfType(typeof(StatusCodeResult));

            _examService.Verify(x => x.GetExamResults(), Times.Exactly(1));

        }
        [Fact]
        public async void get_exam_results_success()
        {
            var _result = new List<ExamResult>
            {
                new ExamResult { Id = 1, StudentId = 1, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 90 },
                new ExamResult { Id = 2, StudentId = 2, LessonId = "M2", Date = new DateTime(2024, 05, 05), Mark = 90 }
            };

            _examService.Setup(x => x.GetExamResults()).ReturnsAsync(_result);

            var result = await _controller.GetExamResults();



            result.ShouldBeOfType(typeof(OkObjectResult));
            _examService.Verify(x => x.GetExamResults(), Times.Exactly(1));


        }
    }
}