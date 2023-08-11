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
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<GradeDTO, GradeDTO>();
            CreateMap<SubjectDTO, Subject>();
            CreateMap<GradeDTO, Grade>();
        }
    }
}
