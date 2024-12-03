using Microsoft.AspNetCore.Mvc;

namespace Erk.Controllers
{
    public class OdemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
