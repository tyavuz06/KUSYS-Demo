using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface IStudentBusiness
    {
        /// <summary>
        /// Creates a new Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Add(StudentDetailDTO student);

        /// <summary>
        /// Deletes a Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Delete(int id);

        /// <summary>
        /// Updates a Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>BaseResponseModel</returns>
        public BaseResponseModel Update(StudentDetailDTO student);

        /// <summary>
        /// Gets all Students
        /// </summary>
        /// <param name="student"></param>
        /// <returns>StudentListGetResponseModel</returns>
        public StudentListGetResponseModel GetList();

        /// <summary>
        /// Gets detail of a Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>StudentDetailGetResponeModel</returns>
        public StudentDetailGetResponeModel GetDetail(int id);
    }
}
