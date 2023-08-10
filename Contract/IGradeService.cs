using WebAPI.DTO;

namespace WebAPI.Contract
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDTO>> GetAllAsync();
        Task<GradeDTO> GetByIdAsync(int id);
        Task<GradeDTO> CreateAsync(GradeDTO gradeDTO);
        Task<GradeDTO> UpdateAsync(int id, GradeDTO gradeDTO);
        Task DeleteAsync(int id);
    }
}
