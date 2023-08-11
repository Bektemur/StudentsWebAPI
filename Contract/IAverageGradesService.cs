using WebAPI.DTO;

namespace WebAPI.Contract
{
    public interface IAverageGradesService
    {
        public List<AverageGradeDTO> GetAverageGradesByStudentId(int studentId);
        public List<AverageGradeByGroupDTO> GetAverageGradesByGroup(string groupName);
    }
}
