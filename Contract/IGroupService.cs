using WebAPI.DTO;

namespace WebAPI.Contract
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetAllAsync();
        Task<GroupDTO> GetByIdAsync(int id);
        Task<GroupDTO> CreateAsync(GroupDTO groupDTO);
        Task<GroupDTO> UpdateAsync(int id, GroupDTO groupDTO);
        Task DeleteAsync(int id);
    }
}
