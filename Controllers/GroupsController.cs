using Microsoft.AspNetCore.Mvc;
using WebAPI.Contract;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private IGroupService _service;
        public GroupsController(IGroupService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(GroupDTO group)
        {
            if (group != null)
            {
                _service.Add(group);
                return Ok(group);
            }
            return BadRequest();
        }

    }
}
