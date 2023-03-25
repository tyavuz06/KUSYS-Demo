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

        public BaseResponseModel Add(StudentDetailDTO student)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = AutoMap.AutoMapper.Map<StudentDetailDTO, Student>(student);
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

        public BaseResponseModel Delete(int id)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == id);

                if (entity != null)
                {
                    _service.Delete(entity);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public StudentDetailGetResponeModel GetDetail(int id)
        {
            var responseModel = new StudentDetailGetResponeModel();

            try
            {
                var entity = _service.Get(x => x.Id == id);

                if (entity != null)
                {
                    responseModel.Student = AutoMap.AutoMapper.Map<Student, StudentDetailDTO>(entity);
                    responseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    responseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                responseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return responseModel;
        }

        public StudentListGetResponseModel GetList()
        {
            var responseModel = new StudentListGetResponseModel();

            try
            {
                var list = _service.GetListWithoutTask();

                if (list != null)
                {
                    responseModel.StudentList = AutoMap.AutoMapper.Map<List<Student>, List<StudentDTO>>(list);
                    responseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    responseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                responseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return responseModel;
        }

        public BaseResponseModel Update(StudentDetailDTO student)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == student.Id);

                if (entity != null)
                {
                    entity = AutoMap.AutoMapper.Map<StudentDetailDTO, Student>(student);
                    _service.Update(entity);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }
    }
}
