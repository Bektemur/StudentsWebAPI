using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contract;
using WebAPI.DTO;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private IGroupService _groupService;
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetAllGroups()
        {
            var groups = await _groupService.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroupById(int id)
        {
            var group = await _groupService.GetByIdAsync(id);
            if (group == null)
                return NotFound();

            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<GroupDTO>> CreateGroup(GroupDTO groupDTO)
        {
            var createdGroup = await _groupService.CreateAsync(groupDTO);
            return CreatedAtAction(nameof(GetGroupById), createdGroup);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroupDTO>> UpdateGroup(int id, GroupDTO groupDTO)
        {
            var updatedGroup = await _groupService.UpdateAsync(id, groupDTO);
            if (updatedGroup == null)
                return NotFound();

            return Ok(updatedGroup);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            await _groupService.DeleteAsync(id);
            return NoContent();
        }

    }
}
