using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.Common;
using KUSYS_Demo.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBusiness _studentBusiness;

        public StudentController(IStudentBusiness studentBusiness) => (_studentBusiness) = (studentBusiness);

        [HttpPut]
        [Route("Create")]
        public IActionResult Create(StudentDetailDTO student)
        {
            if (ModelState.IsValid)
            {
                var response = _studentBusiness.Add(student);
                switch (response.Code)
                {
                    case (int)SystemConstans.CODES.SUCCESS:
                        return Ok(response);
                    case (int)SystemConstans.CODES.NOTFOUND:
                        return NotFound(response);
                    case (int)SystemConstans.CODES.SYSTEMERROR:
                        return StatusCode(500, response);
                    default:
                        return NotFound();
                }
            }

            return StatusCode(200, "Model Is Not Valid");
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var response = _studentBusiness.Delete(id);

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(StudentDetailDTO student)
        {
            if (ModelState.IsValid)
            {
                var response = _studentBusiness.Update(student);

                switch (response.Code)
                {
                    case (int)SystemConstans.CODES.SUCCESS:
                        return Ok(response);
                    case (int)SystemConstans.CODES.NOTFOUND:
                        return NotFound(response);
                    case (int)SystemConstans.CODES.SYSTEMERROR:
                        return StatusCode(500, response);
                    default:
                        return NotFound();
                }
            }

            return StatusCode(200, "Model Is Not Valid");
        }

        [ResponseCache(Duration = 500)]
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var response = _studentBusiness.GetList();

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }

        [ResponseCache(Duration = 1000)]
        [HttpGet]
        [Route("GetDetail")]
        public IActionResult GetDetail(int id)
        {
            var response = _studentBusiness.GetDetail(id);

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }
    }
}
