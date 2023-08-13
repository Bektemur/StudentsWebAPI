using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationContext;
using WebAPI.Contract;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GroupService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            var groups = await _context.Groups.ToListAsync();
            return _mapper.Map<IEnumerable<Group>>(groups);
        }

        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            return _mapper.Map<GroupDTO>(group);
        }

        public async Task<GroupDTO> CreateAsync(GroupDTO groupDTO)
        {
            var group = _mapper.Map<Group>(groupDTO);
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return _mapper.Map<GroupDTO>(group);
        }

        public async Task<GroupDTO> UpdateAsync(int id, GroupDTO groupDTO)
        {
            var existingGroup = await _context.Groups.FindAsync(id);
            if (existingGroup == null)
                return null;

            _mapper.Map(groupDTO, existingGroup);
            await _context.SaveChangesAsync();
            return _mapper.Map<GroupDTO>(existingGroup);
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
