using KUSYS_Demo.Business;
using KUSYS_Demo.Common;
using KUSYS_Demo.Common.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Create(StudentDTO student)
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
        public IActionResult Delete()
        {
            _studentBusiness.Delete();
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update()
        {
            _studentBusiness.Update();
            return Ok();
        }
    }
}
