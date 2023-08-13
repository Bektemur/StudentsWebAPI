using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentDTO, Student>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<GradeDTO, GradeDTO>().ReverseMap();
            CreateMap<SubjectDTO, Subject>().ReverseMap();
            CreateMap<GradeDTO, Grade>().ReverseMap();
        }
    }
}
