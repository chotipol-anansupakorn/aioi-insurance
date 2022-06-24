using Microsoft.AspNetCore.Mvc;

namespace aioi_insurance.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
