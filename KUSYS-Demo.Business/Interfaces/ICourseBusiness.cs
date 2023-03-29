using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface ICourseBusiness
    {
        /// <summary>
        /// Creates a new Course Element
        /// </summary>
        /// <param name="course">It Take CourseDTO Model</param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Add(CourseDTO course);

        /// <summary>
        /// Deletes a Course Element
        /// </summary>
        /// <param name="course">It Take CourseDTO Model</param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Delete(int id);

        /// <summary>
        /// Updates a Course Element
        /// </summary>
        /// <param name="course">It Take CourseDTO Model</param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Update(CourseDTO course);

        /// <summary>
        /// Gets All Course List
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public CourseListGetResponseModel GetAll();
    }
}
