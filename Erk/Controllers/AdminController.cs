using Erk.DTO.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Erk.Controllers
{
    public class AdminController : Controller
    {
        private readonly ErkDbContext _context;

        public AdminController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminEkle(Admin admin)
        {
            if (admin != null)
            {
                var c = _context.Admin.Add(admin);
                _context.SaveChanges();
            }
            return RedirectToAction("AdminListe");
        }

        public IActionResult AdminGuncelle(int id)
        {
            var adm = _context.Admin.Find(id);
            if (adm == null) // Eğer admin bulunamazsa hata sayfasına yönlendir
            {
                return NotFound();
            }
            return View(adm); // Admin bilgileri ile güncelleme formunu döndür
        }
        [HttpPost]
        public IActionResult AdminGuncelle(Admin admin)
        {
            if (ModelState.IsValid) // Model doğrulama geçerliyse
            {
                _context.Entry(admin).State = EntityState.Modified; // Admin güncelleme
                _context.SaveChanges(); // Veritabanına kaydetme
                return RedirectToAction("AdminListe"); // Liste sayfasına yönlendir
            }
            return View(admin); // Hatalı form verisi ile tekrar formu döndür
        }

        public IActionResult AdminListe()
        {
            var lst = _context.Admin.ToList();
            return View(lst);
        }
    }
}
