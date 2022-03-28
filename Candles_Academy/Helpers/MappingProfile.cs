using AutoMapper;
using Candles_Academy.Dtos;
using Candles_Academy.Models;

namespace Candles_Academy.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherDetailsDto>().ReverseMap();
            CreateMap<TeacherDto, Teacher>()
                .ForMember(src => src.Poster, opt => opt.Ignore()).ReverseMap();

            CreateMap<PostCourseDto, Course>()
                .ForMember(src => src.Teachers, opt => opt.Ignore())
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<PutCourseDto, Course>()
             .ForMember(src => src.Teachers, opt => opt.Ignore());

            CreateMap<Course, GetCourseDetails>();
            CreateMap<Teacher, GetTeacherModel>();


        }
    }
}
