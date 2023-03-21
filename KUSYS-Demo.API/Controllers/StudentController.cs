using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPut]
        [Route("Create")]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update()
        {
            return Ok();
        }
    }
}
