using App_Hexagonal.Api.student.Dtos.request;
using App_Hexagonal.Api.student.mapping;
using App_Hexagonal.Application.Common.security;
using App_Hexagonal.Application.student.query;
using App_Hexagonal.Application.student.useCase;
using App_Hexagonal.Application.student.useCase.command;
using App_Hexagonal.student.Dtos.response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Hexagonal.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudentUseCase _createStudent;
        private readonly GetAllStudentsUseCase _getAllStudents;
        private readonly GetStudentByIdUseCase _getStudentById;
        private readonly UpdateStudentUseCase _updateStudent;
        private readonly DeleteStudentUseCase _deleteStudent;

        public StudentController(
             CreateStudentUseCase createStudent,
             GetAllStudentsUseCase getAllStudents,
             GetStudentByIdUseCase getStudentById,
             UpdateStudentUseCase updateStudent,
             DeleteStudentUseCase deleteStudent)
        {
            _createStudent = createStudent;
            _getAllStudents = getAllStudents;
            _getStudentById = getStudentById;
            _updateStudent = updateStudent;
            _deleteStudent = deleteStudent;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] StudentCreateRequest request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _createStudent.ExecuteAsync(request.ToCommand());
            var response = student.ToResponse();

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                response
            );
        }

        [HttpGet]
        [Authorize(Policy = Policies.TenantUser)]
        [Authorize(Policy = Policies.TenantAdmin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<StudentResponse>>> GetAll()
        {
            var result = await _getAllStudents.ExecuteAsync(new GetAllStudentsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<StudentResponse>> GetById(Guid id)
        {
            var result = await _getStudentById.ExecuteAsync(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] StudentCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _updateStudent.ExecuteAsync(request.ToCommand(id));
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteStudent.ExecuteAsync(new DeleteStudentCommand(id));
            return NoContent();
        }
    }
}
