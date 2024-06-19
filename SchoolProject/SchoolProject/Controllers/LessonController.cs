using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core;
using SchoolProject.Service;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson(Lesson request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  await  _service.AddLesson(request);
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
        public async Task<IActionResult> GetLessons()
        {
            try
            {
                var result =await _service.GetLessons();
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
