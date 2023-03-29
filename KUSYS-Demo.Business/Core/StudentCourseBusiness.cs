using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common.Models;
using KUSYS_Demo.Data.Entities;
using KUSYS_Demo.Data.Repository.Interfaces;

namespace KUSYS_Demo.Business.Core
{
    public class StudentCourseBusiness : IStudentCourseBusiness
    {
        private readonly IStudentCourseDal _service;
        private readonly IMapper _mapper;
        public StudentCourseBusiness(IStudentCourseDal service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public BaseResponseModel Add(StudentCourseDTO model)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var existData = _service.GetListWithoutTask(x => x.StudentId == model.StudentId);
                var addedIds = model.SelectedCourses.Where(x => !existData.Any(y => y.CourseId == x)).ToList();
                var deletedDatas = existData.Where(x => !model.SelectedCourses.Any(y => y == x.CourseId)).ToList();

                if (existData.Count() == 0)
                {
                    var entityList = new List<StudentCourse>();

                    model.SelectedCourses.ToList().ForEach(id =>
                    {
                        entityList.Add(new StudentCourse()
                        {
                            CourseId = id,
                            StudentId = model.StudentId
                        });
                    });

                    _service.Add(entityList);
                }
                else
                {
                    //{1,2,3}   {1,3,4}
                    if (addedIds.Count() > 0)
                    {
                        var entityList = new List<StudentCourse>();

                        addedIds.ForEach(id =>
                        {
                            entityList.Add(new StudentCourse()
                            {
                                CourseId = id,
                                StudentId = model.StudentId
                            });
                        });

                        _service.Add(entityList);
                    }

                    if (deletedDatas.Count() > 0)
                        _service.Delete(deletedDatas);
                }


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

        public BaseResponseModel Update(StudentCourseDTO model)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == model.Id);

                if (entity != null)
                {
                    entity = _mapper.AutoMapper.Map<StudentCourseDTO, StudentCourse>(model);
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

        public StudentCourseGetListResponseModel GetList()
        {
            var responseModel = new StudentCourseGetListResponseModel();

            try
            {
                var list = _service.EagerLoadingWithParams(null, x => x.Student, x => x.Course);

                if (list != null)
                {

                    var mapped = _mapper.AutoMapper.Map<List<StudentCourse>, List<StudentCourseDTO>>(list);
                    responseModel.List = mapped.GroupBy(x => new { x.StudentId, x.StudentName }, x => x.CourseName, (key, g) => new { StudentId = key.StudentId, StudentName = key.StudentName, List = g.ToList() });

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

        public StudentCourseGetListResponseModel GetListForStudent(int id)
        {
            var responseModel = new StudentCourseGetListResponseModel();

            try
            {
                var list = _service.EagerLoadingWithParams(x => x.StudentId == id, x => x.Student, x => x.Course);

                if (list != null)
                {

                    var mapped = _mapper.AutoMapper.Map<List<StudentCourse>, List<StudentCourseDTO>>(list);
                    responseModel.List = mapped.GroupBy(x => new { x.StudentId, x.StudentName }, x => x.CourseName, (key, g) => new { StudentId = key.StudentId, StudentName = key.StudentName, List = g.ToList() });

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
    }
}
