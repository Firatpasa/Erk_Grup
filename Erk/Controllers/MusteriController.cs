using Erk.DTO.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Erk.Controllers
{
    public class MusteriController : Controller
    {
        private readonly ErkDbContext _context;

        public MusteriController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MusteriListele()
        {
            var lst = _context.Musteri.ToList();
            return View(lst);
        }
        public IActionResult MusteriEkle()
        {
            return View();
        }

        public IActionResult MusteriEkle(Musteri mstr)
        {
            return View();
        }

        public IActionResult MusteriGuncelle()
        {
            return View();
        }
        public IActionResult MusteriGuncelle(Musteri mstr)
        {
            return View();
        }

        public IActionResult MusteriSil()
        {
            return View();
        }
        public IActionResult MusteriAra()
        {
            return View();
        }
    }
}
