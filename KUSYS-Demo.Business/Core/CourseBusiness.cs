using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;
using KUSYS_Demo.Data.Entities;
using KUSYS_Demo.Data.Repository.Interfaces;

namespace KUSYS_Demo.Business.Core
{
    public class CourseBusiness : ICourseBusiness
    {
        private readonly ICourseDal _service;
        private readonly IMapper _mapper;
        public CourseBusiness(ICourseDal service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public BaseResponseModel Add(CourseDTO course)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _mapper.AutoMapper.Map<CourseDTO, Course>(course);
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

        public BaseResponseModel Update(CourseDTO course)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == course.Id);

                if (entity != null)
                {
                    entity = _mapper.AutoMapper.Map<CourseDTO, Course>(course);
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
