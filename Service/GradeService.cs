using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationContext;
using WebAPI.Contract;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class GradeService : IGradeService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GradeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GradeDTO>> GetAllAsync()
        {
            var grades = await _context.Grades.ToListAsync();
            return _mapper.Map<IEnumerable<GradeDTO>>(grades);
        }

        public async Task<GradeDTO> GetByIdAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            return _mapper.Map<GradeDTO>(grade);
        }

        public async Task<GradeDTO> CreateAsync(GradeDTO gradeDTO)
        {
            var grade = _mapper.Map<Grade>(gradeDTO);
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return _mapper.Map<GradeDTO>(grade);
        }

        public async Task<GradeDTO> UpdateAsync(int id, GradeDTO gradeDTO)
        {
            var existingGrade = await _context.Grades.FindAsync(id);
            if (existingGrade == null)
                return null;

            _mapper.Map(gradeDTO, existingGrade);
            await _context.SaveChangesAsync();
            return _mapper.Map<GradeDTO>(existingGrade);
        }

        public async Task DeleteAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
