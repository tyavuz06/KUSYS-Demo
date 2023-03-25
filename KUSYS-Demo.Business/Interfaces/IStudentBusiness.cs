using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface IStudentBusiness
    {
        public BaseResponseModel Add(StudentDetailDTO student);

        public BaseResponseModel Delete(int id);

        public BaseResponseModel Update(StudentDetailDTO student);

        public StudentListGetResponseModel GetList();

        public StudentDetailGetResponeModel GetDetail(int id);
    }
}
