using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface IStudentCourseBusiness
    {
        /// <summary>
        /// Creates a new Student-Course Match
        /// </summary>
        /// <param name="course"></param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Add(StudentCourseDTO course);

        /// <summary>
        /// Deletes a Student-Course Match
        /// </summary>
        /// <param name="course"></param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Delete(int id);

        /// <summary>
        /// Updates a Student-Course Match
        /// </summary>
        /// <param name="course"></param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Update(StudentCourseDTO course);

        /// <summary>
        /// Gets All Student-Course Match List
        /// </summary>
        /// <returns>StudentCourseGetListResponseModel</returns>
        public StudentCourseGetListResponseModel GetList();
    }
}
