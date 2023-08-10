using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Contract
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(int id);
        Task<StudentDTO> CreateAsync(StudentDTO studentDTO);
        Task<StudentDTO> UpdateAsync(int id, StudentDTO studentDTO);
        Task DeleteAsync(int id);
    }
}
