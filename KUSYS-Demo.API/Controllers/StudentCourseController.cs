using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common;
using Microsoft.AspNetCore.Mvc;
using KUSYS_Demo.Business.Interfaces;

namespace KUSYS_Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseBusiness _studentCourseBusiness;

        public StudentCourseController(IStudentCourseBusiness studentCourseBusiness) => (_studentCourseBusiness) = (studentCourseBusiness);

        /// <summary>
        /// Create a new Student-Course Match
        /// </summary>
        /// <param name="course"></param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        [Route("Create")]
        public IActionResult Create(StudentCourseDTO course)
        {
            if (ModelState.IsValid)
            {
                var response = _studentCourseBusiness.Add(course);
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

        /// <summary>
        /// Deletes a Student-Course Match
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var response = _studentCourseBusiness.Delete(id);

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

        /// <summary>
        /// Updates a Student-Course Match
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(StudentCourseDTO course)
        {
            if (ModelState.IsValid)
            {
                var response = _studentCourseBusiness.Update(course);

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

        /// <summary>
        /// Gets AllStudent-Course Matches
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            var response = _studentCourseBusiness.GetList();

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

        /// <summary>
        /// Gets AllStudent-Course Matches For a Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("GetListForStudent")]
        public IActionResult GetListForStudent(int id)
        {
            var response = _studentCourseBusiness.GetListForStudent(id);

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
