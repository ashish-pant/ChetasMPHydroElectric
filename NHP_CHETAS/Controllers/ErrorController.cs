using Microsoft.AspNetCore.Mvc;

namespace NHP_CHETAS.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
