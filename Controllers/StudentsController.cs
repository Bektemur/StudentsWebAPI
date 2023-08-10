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

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IStudentService _service;
        
        public StudentsController(ILogger<StudentsController> logger, IConfiguration configuration, IStudentService studentService)
        {
            _logger = logger;
            _configuration = configuration;
            _service = studentService;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(StudentDTO student)
        {
            if (student != null)
            {
                _service.Add(student);
                return Ok(student);
            }
            return BadRequest();
        }
    }
}
