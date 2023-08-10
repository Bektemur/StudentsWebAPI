using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Contract
{
    public interface IStudentService
    {
        public void Add(StudentDTO student);
        public void Update(StudentDTO student, int Id);
        public void Delete(int Id);
        public void Find();
    }
}
