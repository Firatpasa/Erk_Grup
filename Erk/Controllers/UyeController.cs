using Erk.DTO.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Erk.Controllers
{
    public class UyeController : Controller
    {
        private readonly ErkDbContext _context;

        public UyeController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UyeListesi()
        {
            var mstrLst = _context.Musteri.ToList();
            return View(mstrLst);
        }
        public IActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UyeOl(Musteri mstr)
        {
            return View();
        }
        public IActionResult UyeGuncelle(int id)
        {
            return View();
        }

        public IActionResult UyeGuncelle()
        {
            return View();
        }
        public IActionResult UyeSil()
        {
            return View();
        }
        public IActionResult UyeAra()
        {
            return View();
        }

    }
}
