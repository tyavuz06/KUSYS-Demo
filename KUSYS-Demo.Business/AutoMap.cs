using AutoMapper;
using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Data.Entities;

namespace KUSYS_Demo.Business
{
    public class AutoMap : IMapper
    {
        public Mapper AutoMapper { get; set; }

        public AutoMap()
        {
            AutoMapper = InitializeAutomapper();
        }

        private AutoMapper.Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDetailDTO>().ReverseMap();
                cfg.CreateMap<Course, CourseDTO>().ReverseMap();
                cfg.CreateMap<StudentCourse, StudentCourseDTO>()
                .ForMember(dest => dest.CourseName, act => act.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.StudentName, act => act.MapFrom(src => string.Concat(src.Student.Name, " ", src.Student.SurName)));
                cfg.CreateMap<StudentCourseDTO, StudentCourse>();
            });
            
            var mapper = new AutoMapper.Mapper(config);
            return mapper;
        }
    }
}
