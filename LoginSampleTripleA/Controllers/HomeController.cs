using Microsoft.AspNetCore.Mvc;

namespace LoginSampleTripleA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
