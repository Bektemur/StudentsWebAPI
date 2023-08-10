using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationContext;
using WebAPI.Contract;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public SubjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDTO>> GetAllAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return _mapper.Map<IEnumerable<SubjectDTO>>(subjects);
        }

        public async Task<SubjectDTO> GetByIdAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            return _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<SubjectDTO> CreateAsync(SubjectDTO subjectDTO)
        {
            var subject = _mapper.Map<Subject>(subjectDTO);
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubjectDTO>(subject);
        }

        public async Task<SubjectDTO> UpdateAsync(int id, SubjectDTO subjectDTO)
        {
            var existingSubject = await _context.Subjects.FindAsync(id);
            if (existingSubject == null)
                return null;

            _mapper.Map(subjectDTO, existingSubject);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubjectDTO>(existingSubject);
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
    }
}
