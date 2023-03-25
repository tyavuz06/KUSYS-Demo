using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface IStudentCourseBusiness
    {
        public BaseResponseModel Add(StudentCourseDTO course);

        public BaseResponseModel Delete(int id);

        public BaseResponseModel Update(StudentCourseDTO course);

        public StudentCourseGetListResponseModel GetList();
    }
}
