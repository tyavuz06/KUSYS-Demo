using KUSYS_Demo.Business;
using KUSYS_Demo.Common.DTO;
using KUSYS_Demo.Common;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.API.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseBusiness _courseBusiness;

        public CourseController(ICourseBusiness courseBusiness) => (_courseBusiness) = (courseBusiness);

        [HttpPut]
        [Route("Create")]
        public IActionResult Create(CourseDTO course)
        {
            if (ModelState.IsValid)
            {
                var response = _courseBusiness.Add(course);
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
            var response = _courseBusiness.Delete(id);

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
        public IActionResult Update(CourseDTO course)
        {
            if (ModelState.IsValid)
            {
                var response = _courseBusiness.Update(course);

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
    }
}
