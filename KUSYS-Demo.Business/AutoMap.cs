using AutoMapper;
using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                cfg.CreateMap<Course, CourseDTO>().ReverseMap();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new AutoMapper.Mapper(config);
            return mapper;
        }
    }
}
