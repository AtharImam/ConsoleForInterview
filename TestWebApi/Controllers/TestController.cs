using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            TestResponse<string> testResponse = new TestResponse<string>();
            testResponse.Data = "Athar Imam";
            return new OkObjectResult(testResponse);
        }

        [HttpGet]
        [Route(" ")]
        public IActionResult Index1()
        {
            TestResponse<string> testResponse = new TestResponse<string>();
            testResponse.Data = "Athar Imam1";
            return new OkObjectResult(testResponse);
        }
    }
}
