using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business
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
