using Microsoft.AspNetCore.Mvc;

namespace Ch04MovieListDahlstrom.Controllers
{
    [Route("Custom/[controller]/[action]")]
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return Content("Other Controller!!");
        }
    }
}
