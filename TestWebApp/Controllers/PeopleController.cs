using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
