using Erk.DTO.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.IO;

namespace Erk.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ErkDbContext _context;

        public KategoriController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KategoriListe()
        {
            var ktgr = _context.Kategori.ToList();
            return View(ktgr);
        }

        public IActionResult KategoriEkle()
        {
            return View(new Kategori());  
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kategori kategori)
        {
            if (kategori == null)
            {
                return View();  // Boş bir kategori geldiğinde, işlemi iptal et
            }

            if (ModelState.IsValid)
            {
                // Trimle ve büyük harfe çevir
                kategori.KategoriAd = kategori.KategoriAd.Trim().ToUpper();

                // Kategori zaten var mı diye kontrol et
                var existingCategory = _context.Kategori
                    .FirstOrDefault(k => k.KategoriAd == kategori.KategoriAd);

                if (existingCategory != null)
                {
                    ModelState.AddModelError("", "Bu kategori zaten mevcut.");
                    return View(kategori);
                }

                // Yeni kategori ekle
                _context.Kategori.Add(kategori);
                _context.SaveChanges(); // Değişiklikleri kaydet
                return RedirectToAction("Index"); // Listeleme sayfasına yönlendir
            }

            return View(kategori);
        }

        public IActionResult KategoriGuncelle(int id)
        {
            var kategori = _context.Kategori.FirstOrDefault(k => k.KategoriID == id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        [HttpPost]
        public IActionResult KategoriGuncelleGuncelle(int id, Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                // Trimle ve büyük harfe çevir
                kategori.KategoriAd = kategori.KategoriAd.Trim().ToUpper();

                // Kategori adı zaten var mı diye kontrol et (aynı isme sahip fakat farklı ID'ler ile)
                var existingCategory = _context.Kategori
                    .FirstOrDefault(k => k.KategoriAd == kategori.KategoriAd && k.KategoriID != id);

                if (existingCategory != null)
                {
                    ModelState.AddModelError("", "Bu kategori adı zaten var.");
                    return View(kategori);
                }

                var categoryToUpdate = _context.Kategori.FirstOrDefault(k => k.KategoriID == id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.KategoriAd = kategori.KategoriAd; // Kategori adını güncelle
                    _context.SaveChanges(); // Değişiklikleri kaydet
                    return RedirectToAction("Index"); // Listeleme sayfasına yönlendir
                }
            }

            return View(kategori);
        }

        public IActionResult KategoriSil(int id)
        {
            var kategori = _context.Kategori.FirstOrDefault(k => k.KategoriID == id);
            if (kategori == null)
            {
                return NotFound();
            }

            _context.Kategori.Remove(kategori); // Kategoriyi sil
            _context.SaveChanges(); // Değişiklikleri kaydet
            return RedirectToAction("KategoriListesi"); // Listeleme sayfasına yönlendir
        }
        public IActionResult KategoriListesi(string searchTerm = "")
        {
            var kategoriler = string.IsNullOrEmpty(searchTerm)
                ? _context.Kategori.ToList()  // Arama terimi yoksa tüm kategorileri listele
                : _context.Kategori
                    .Where(k => k.KategoriAd.Contains(searchTerm))  // Arama terimi ile eşleşen kategorileri getir
                    .ToList();

            ViewData["SearchTerm"] = searchTerm; // Arama terimini view'a gönder

            return View(kategoriler); // Kategorileri View'a gönder
        }

        public IActionResult KategoriExcelEkle()
        {
            return View(new Kategori());
        }


        /*Kategorileri Excelden Kayıt Etme*/
        [HttpPost]
        public IActionResult KategoriExcelEkle(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ModelState.AddModelError("", "Lütfen bir Excel dosyası seçin.");
                return View();
            }

            try
            {
                // EPPlus lisansını kabul etmek için
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using var package = new ExcelPackage(excelFile.OpenReadStream());
                var worksheet = package.Workbook.Worksheets[0]; // İlk sayfa
                var rowCount = worksheet.Dimension.Rows; // Toplam satır sayısı

                for (int row = 2; row <= rowCount; row++) // 2. satırdan başla (başlık atla)
                {
                    var kategoriAd = worksheet.Cells[row, 1].Text.Trim();
                    var kategoriDurumu = bool.TryParse(worksheet.Cells[row, 2].Text, out var durumu) ? durumu : false;
                    var ustKategoriID = int.TryParse(worksheet.Cells[row, 3].Text, out var id) ? id : 0;

                    // Kategori zaten varsa eklemeyi atla
                    if (_context.Kategori.Any(k => k.KategoriAd == kategoriAd))
                        continue;

                    var kategori = new Kategori
                    {
                        KategoriAd = kategoriAd,
                        KategoriDurumu = kategoriDurumu,
                        KategoriUstKategoriID = ustKategoriID,
                        KategoriYuklenmeTarihi = DateTime.Now
                    };

                    _context.Kategori.Add(kategori);
                }

                _context.SaveChanges();
                TempData["Success"] = "Excel'den kategoriler başarıyla eklendi.";
                return RedirectToAction("KategoriListesi");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                return View();
            }
        }

    }
}
