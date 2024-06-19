using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core;
using SchoolProject.Service;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   await _service.AddStudent(request);
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
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var result =await _service.GetStudents();
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(500);

            }

        }
    }
}
