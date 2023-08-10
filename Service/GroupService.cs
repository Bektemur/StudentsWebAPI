using AutoMapper;
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
        public void Add(GroupDTO group)
        {
            var data = _mapper.Map<Group>(group);
            _context.Groups.Add(data);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public void Update(GroupDTO group, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
