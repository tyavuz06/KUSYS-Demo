using KUSYS_Demo.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Common.Models
{
    public class StudentCourseGetListResponseModel : BaseResponseModel
    {
        public StudentCourseGetListResponseModel() { }

        public List<StudentCourseDTO> List { get; set; }
    }
}
