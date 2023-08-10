using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contract;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDTO>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDTO>> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
                return NotFound();

            return Ok(subject);
        }

        [HttpPost("add")]
        public async Task<ActionResult<SubjectDTO>> CreateSubject(SubjectDTO subjectDTO)
        {
            var createdSubject = await _subjectService.CreateAsync(subjectDTO);
            return CreatedAtAction(nameof(GetSubjectById), createdSubject);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<SubjectDTO>> UpdateSubject(int id, SubjectDTO subjectDTO)
        {
            var updatedSubject = await _subjectService.UpdateAsync(id, subjectDTO);
            if (updatedSubject == null)
                return NotFound();

            return Ok(updatedSubject);
        }

        [HttpDelete("delete{id}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            await _subjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
