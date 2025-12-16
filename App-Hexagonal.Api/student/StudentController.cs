using App_Hexagonal.Application.student.ports.input;
using App_Hexagonal.Domain.student.model;
using App_Hexagonal.Infrastructura.student.ports.input.rest.mapping;
using App_Hexagonal.Infrastructura.student.ports.input.rest.model.request;
using Microsoft.AspNetCore.Mvc;

namespace App_Hexagonal.Api.student
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServicePort _studentService;

        public StudentController(IStudentServicePort studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = request.ToDomain();
            await _studentService.save(student);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _studentService.findAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(long id)
        {
            var student = await _studentService.findById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] StudentCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = request.ToDomain();
            var updated = await _studentService.update(id, student);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _studentService.deleteById(id);
            return NoContent();
        }
    }
}
