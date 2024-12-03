using Microsoft.AspNetCore.Mvc;

namespace Erk.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
