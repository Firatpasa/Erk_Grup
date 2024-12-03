using Erk.DTO.Entities;
using Erk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Erk.Controllers
{
    public class GirisController : Controller
    {
        private readonly ErkDbContext _context;

        public GirisController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(GirisViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Admin doğrulama (aktiflik durumu kontrolü yapılmıyor)
                var admin = _context.Admin
                    .FirstOrDefault(a => a.AdminEPosta == model.KullaniciAdi && a.AdminSifre == model.Sifre);

                if (admin != null)
                {
                    return RedirectToAction("Index", "Admin");
                }

                // Müşteri doğrulama ve aktiflik durumu kontrolü
                var musteri = _context.Musteri
                    .FirstOrDefault(m => m.MusteriEPosta == model.KullaniciAdi && m.MusteriEPosta == model.Sifre && m.AktifMi);

                if (musteri != null)
                {
                    return RedirectToAction("Index", "Musteri");
                }

                // Eğer giriş bilgileri doğru değilse veya aktif değilse
                ModelState.AddModelError("", "Kullanıcı adı, şifre ya da aktiflik durumu hatalı.");
            }

            return View(model);
        }
    }
}
