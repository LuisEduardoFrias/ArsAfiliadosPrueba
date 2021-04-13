using Microsoft.AspNetCore.Mvc;

namespace ArsAfiliados.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
