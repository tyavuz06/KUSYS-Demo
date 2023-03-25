using AutoMapper;
using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Data.Entities;

namespace KUSYS_Demo.Business
{
    public class AutoMap
    {
        public static Mapper AutoMapper { get; set; }

        public AutoMap()
        {
            AutoMapper = InitializeAutomapper();
        }

        private AutoMapper.Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDetailDTO>().ReverseMap();
                cfg.CreateMap<Course, CourseDTO>().ReverseMap();
                cfg.CreateMap<StudentCourse, StudentCourseDTO>()
                .ForMember(dest => dest.CourseName, act => act.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.StudentName, act => act.MapFrom(src => src.Student.Name));
                //cfg.CreateMap<List<Student>, List<StudentDTO>>().ReverseMap();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new AutoMapper.Mapper(config);
            return mapper;
        }
    }
}
