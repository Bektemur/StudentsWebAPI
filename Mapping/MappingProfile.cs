using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<GroupDTO, Group>();
            CreateMap<SubjectDTO, Subject>();
            CreateMap<GradeDTO, Grade>();
        }
    }
}
