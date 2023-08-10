using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationContext;
using WebAPI.Contract;
using WebAPI.CustomException;
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

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _context.Students.ToListAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> CreateAsync(StudentDTO studentDTO)
        {
            if (GetEmail(studentDTO.Email) > 0)
            {
                throw new DuplicateEmailException(studentDTO.Email);
            }
            var student = _mapper.Map<Student>(studentDTO);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> UpdateAsync(int id, StudentDTO studentDTO)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
                return null;

            _mapper.Map(studentDTO, existingStudent);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentDTO>(existingStudent);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
        private int GetEmail(string email)
        {
            return _context.Students.Count(x => x.Email == email);
        }
    }
}
