using AutoMapper;
using WebAPI.ApplicationContext;
using WebAPI.Contract;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class StudentService : IStudentService 
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StudentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(StudentDTO student)
        {
            var data = _mapper.Map<Student>(student);
            _context.Students.Add(data);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
           
            var student = _context.Students.Where(v=>v.Id == Id).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            _context.SaveChanges();
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public void Update(StudentDTO student, int Id)
        {
            var data = _mapper.Map<Student>(student);
            _context.Students.Update(data);
            _context.SaveChanges();
        }
        
       

    }
}
