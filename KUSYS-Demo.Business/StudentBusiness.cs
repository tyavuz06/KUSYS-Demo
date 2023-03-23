using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;
using KUSYS_Demo.Data;
using KUSYS_Demo.Data.Entities;
using KUSYS_Demo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentDal _service;
        public StudentBusiness(IStudentDal service)
        {
            _service = service;
        }

        public BaseResponseModel Add(StudentDTO student)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = AutoMap.AutoMapper.Map<StudentDTO, Student>(student);
                _service.Add(entity);
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
