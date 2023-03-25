using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;

namespace KUSYS_Demo.Business
{
    public interface ICourseBusiness
    {
        public BaseResponseModel Add(CourseDTO course);

        public BaseResponseModel Delete(int id);

        public BaseResponseModel Update(CourseDTO course);
    }
}
