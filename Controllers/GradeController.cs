using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contract;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/grades")]
    [Authorize]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDTO>>> GetAllGrades()
        {
            var grades = await _gradeService.GetAllAsync();
            return Ok(grades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDTO>> GetGradeById(int id)
        {
            var grade = await _gradeService.GetByIdAsync(id);
            if (grade == null)
                return NotFound();

            return Ok(grade);
        }

        [HttpPost]
        public async Task<ActionResult<GradeDTO>> CreateGrade(GradeDTO gradeDTO)
        {
            var createdGrade = await _gradeService.CreateAsync(gradeDTO);
            return CreatedAtAction(nameof(GetGradeById), createdGrade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GradeDTO>> UpdateGrade(int id, GradeDTO gradeDTO)
        {
            var updatedGrade = await _gradeService.UpdateAsync(id, gradeDTO);
            if (updatedGrade == null)
                return NotFound();

            return Ok(updatedGrade);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGrade(int id)
        {
            await _gradeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
