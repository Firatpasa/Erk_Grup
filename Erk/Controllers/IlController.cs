using Erk.DTO.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Erk.Controllers
{
    public class IlController : Controller
    {
        private readonly ErkDbContext _context;

        public IlController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IlListesi()
        {
            var iller = _context.Il.ToList();
            return View(iller); // İller listesi View'a gönderiliyor
        }

        public IActionResult IlEkle()
        {
            return View(new Il());
        }
        [HttpPost]
        public IActionResult IlEkle(Il il)
        {
            if (ModelState.IsValid)
            {
                il.IlAdi = il.IlAdi.Trim().ToUpper();

                // Aynı ada sahip başka bir il var mı kontrolü
                if (_context.Il.Any(i => i.IlAdi == il.IlAdi))
                {
                    ModelState.AddModelError("", "Bu il adı zaten mevcut.");
                    return View(il);
                }

                _context.Il.Add(il);
                _context.SaveChanges(); // Veritabanına kaydet
                return RedirectToAction("IlListesi");
            }

            return View(il); // Model hatalıysa tekrar forma döner
        }

        // Excel Yükleme Sayfası
        public IActionResult IlEkleExcel()
        {
            return View(); // Excel yükleme formu gösteriliyor
        }

        // Excel'den İl Listesi Ekleme
        [HttpPost]
        public IActionResult IlEkleExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                ModelState.AddModelError("", "Lütfen bir Excel dosyası yükleyin.");
                return View();
            }

            var ilListesi = new List<Il>();

            // EPPlus lisans ayarını yapıyoruz
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                excelFile.CopyTo(stream);
                stream.Position = 0;

                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // İlk sayfa
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Başlık satırından sonraki satırlar
                    {
                        var ilAdi = worksheet.Cells[row, 1].Text.Trim(); // 1. sütundaki veriyi al
                        if (!string.IsNullOrEmpty(ilAdi))
                        {
                            var normalizedIlAdi = ilAdi.ToUpper();

                            // Veritabanında aynı il yoksa listeye ekle
                            if (!_context.Il.Any(i => i.IlAdi == normalizedIlAdi))
                            {
                                ilListesi.Add(new Il { IlAdi = normalizedIlAdi });
                            }
                        }
                    }
                }
            }

            // Veritabanına topluca ekleme
            if (ilListesi.Count > 0)
            {
                _context.Il.AddRange(ilListesi);
                _context.SaveChanges();
            }

            return RedirectToAction("IlListesi"); // Listeye yönlendir
        }

        // İl Güncelleme Sayfası
        public IActionResult IlGuncelle(int id)
        {
            var il = _context.Il.FirstOrDefault(i => i.IlId == id);
            if (il == null)
            {
                return NotFound(); // İl bulunamazsa 404 döner
            }
            return View(il); // Güncellenecek il bilgileri View'a gönderiliyor
        }

        // İl Güncelleme İşlemi
        [HttpPost]
        public IActionResult IlGuncelle(int id, Il il)
        {
            if (ModelState.IsValid)
            {
                var existingIl = _context.Il.FirstOrDefault(i => i.IlId == id);
                if (existingIl != null)
                {
                    // Güncelleme işlemi
                    il.IlAdi = il.IlAdi.Trim().ToUpper();

                    // Aynı ada sahip başka bir il var mı kontrolü
                    if (_context.Il.Any(i => i.IlAdi == il.IlAdi && i.IlId != id))
                    {
                        ModelState.AddModelError("", "Bu il adı zaten mevcut.");
                        return View(il);
                    }

                    existingIl.IlAdi = il.IlAdi;
                    _context.SaveChanges(); // Değişiklikleri kaydet
                    return RedirectToAction("IlListesi"); // Listeye yönlendir
                }
                else
                {
                    return NotFound(); // İl bulunamazsa 404 döner
                }
            }

            return View(il); // Model hatalıysa tekrar forma döner
        }


    }
}
