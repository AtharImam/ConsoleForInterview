using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Successful transmission Get");
        }

        [Authorize(Roles ="Admin")]
        [Route("address")]
        [HttpGet]
        public IActionResult Address()
        {
            return Ok("Successful transmission Address");
        }

        //[HttpGet]
        //public IActionResult GetEmployee(List<Employee> employees)
        //{
        //    return Ok(employees);
        //}

        //[Route("address")]
        //[HttpGet]
        //public IActionResult GetAddres(List<Address> addresses)
        //{
        //    return Ok(addresses);
        //}

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Successful transmission Post");
        }

        //[AcceptVerbs]
        public IActionResult AllVerbs()
        {
            return Ok("Successful transmission All");
        }
    }
}