using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class UserController : Controller
    {
        [Route("users")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Content("List of all users.");
        }

        [Route("users/{userId}")]
        [HttpGet("userId")]
        public IActionResult GetUserById(string userId)
        {
            return Content("User with id: " + userId);
        }
    }
}
