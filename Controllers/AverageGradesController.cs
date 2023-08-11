using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AverageGradesController : ControllerBase
    {
        private readonly IAverageGradesService _averageGradesService;

        public AverageGradesController(IAverageGradesService averageGradesService)
        {
            _averageGradesService = averageGradesService;
        }

        [HttpGet("student/{studentId}")]
        public IActionResult GetAverageGradesByStudentId(int studentId)
        {
            var averageGrades = _averageGradesService.GetAverageGradesByStudentId(studentId);
            return Ok(averageGrades);
        }

        [HttpGet("group/{groupName}")]
        public IActionResult GetAverageGradesByGroup(string groupName)
        {
            var averageGrades = _averageGradesService.GetAverageGradesByGroup(groupName);
            return Ok(averageGrades);
        }
    }
}
