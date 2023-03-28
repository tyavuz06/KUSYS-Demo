using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;
using KUSYS_Demo.Data.Entities;
using KUSYS_Demo.Data.Repository.Interfaces;

namespace KUSYS_Demo.Business.Core
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentDal _service;
        private readonly IMapper _mapper;
        public StudentBusiness(IStudentDal service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public BaseResponseModel Add(StudentDetailDTO student)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _mapper.AutoMapper.Map<StudentDetailDTO, Student>(student);
                _service.Add(entity);
                baseResponseModel.Id = entity.Id;
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
                    responseModel.Student = _mapper.AutoMapper.Map<Student, StudentDetailDTO>(entity);
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
                    responseModel.StudentList = _mapper.AutoMapper.Map<List<Student>, List<StudentDTO>>(list);
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
                    entity = _mapper.AutoMapper.Map<StudentDetailDTO, Student>(student);
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
