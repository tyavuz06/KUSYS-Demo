using KUSYS_Demo.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Common.Models
{
    public class CourseListGetResponseModel: BaseResponseModel
    {
        public CourseListGetResponseModel() { }

        public List<CourseDTO> List { get; set; }
    }
}
