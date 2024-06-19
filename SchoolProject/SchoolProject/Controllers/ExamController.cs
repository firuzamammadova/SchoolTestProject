using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core;
using SchoolProject.Service;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly IExamService _service;

        public ExamController(IExamService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(Exam request)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddExam(request);
                    return Ok(ModelState);

                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            try
            {
                var result = await _service.GetExams();
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(500);

            }
        }
        [HttpGet("GetExamResults")]
        public async Task<IActionResult> GetExamResults()
        {
            try
            {
                var result = await _service.GetExamResults();
                return Ok(result);

            }
            catch (Exception)
            {

                return StatusCode(500);

            }
        }
    }
}