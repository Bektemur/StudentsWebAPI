using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Contract
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllAsync();
        Task<GroupDTO> GetByIdAsync(int id);
        Task<GroupDTO> CreateAsync(GroupDTO groupDTO);
        Task<GroupDTO> UpdateAsync(int id, GroupDTO groupDTO);
        Task DeleteAsync(int id);
    }
}
