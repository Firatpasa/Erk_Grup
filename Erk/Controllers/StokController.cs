using Erk.DTO.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Erk.Controllers
{
    public class StokController : Controller
    {
        private readonly ErkDbContext _context;

        public StokController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StokListesi()
        {
            var lst = _context.Stok.ToList();
            return View(lst);
        }
        
        public IActionResult StokEkle()
        {
            return View(new Stok());
        }

        [HttpPost]
        public IActionResult StokEkle(Stok stok)
        {
            if (stok == null)
            {
                return View();  // Boş bir kategori geldiğinde, işlemi iptal et
            }

            if (ModelState.IsValid)
            {
                // Trimle ve büyük harfe çevir
                stok.StokKodu = stok.StokKodu.Trim().ToUpper();
                stok.StokOlusturulmaTarihi=DateTime.Now;
                // Kategori zaten var mı diye kontrol et
                var existingStok= _context.Stok
                    .FirstOrDefault(s => s.StokKodu== stok.StokKodu);

                if (existingStok != null)
                {
                    ModelState.AddModelError("", "Bu Stok Kodu Zaten Mevcut.");
                    return View(stok);
                }

                // Yeni kategori ekle
                _context.Stok.Add(stok);
                _context.SaveChanges(); // Değişiklikleri kaydet
                return RedirectToAction("StokListesi"); // Listeleme sayfasına yönlendir
            }

            return View(stok);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
