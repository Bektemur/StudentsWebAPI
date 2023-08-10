using WebAPI.DTO;

namespace WebAPI.Contract
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDTO>> GetAllAsync();
        Task<SubjectDTO> GetByIdAsync(int id);
        Task<SubjectDTO> CreateAsync(SubjectDTO subjectDTO);
        Task<SubjectDTO> UpdateAsync(int id, SubjectDTO subjectDTO);
        Task DeleteAsync(int id);
    }
}
