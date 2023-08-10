using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.ApplicationContext;
using WebAPI.Contract;
using WebAPI.DTO;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IConfiguration configuration, IStudentService studentService)
        {
            _logger = logger;
            _configuration = configuration;
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> CreateStudent(StudentDTO studentDTO)
        {
            var createdStudent = await _studentService.CreateAsync(studentDTO);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO>> UpdateStudent(int id, StudentDTO studentDTO)
        {
            var updatedStudent = await _studentService.UpdateAsync(id, studentDTO);
            if (updatedStudent == null)
                return NotFound();

            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
