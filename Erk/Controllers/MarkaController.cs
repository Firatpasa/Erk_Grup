using Erk.DTO.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace Erk.Controllers
{
    public class MarkaController : Controller
    {
        private readonly ErkDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MarkaController(ErkDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult MarkaListe()
        {
            var lst = _context.Marka.ToList();
            return View(lst);
        }

        public IActionResult MarkaEkle()
        {
            return View(new Marka());
        }

        // Marka Ekleme
        [HttpPost]
        public async Task<IActionResult> MarkaEkle(Marka marka, IFormFile markaResim)
        {
            if (ModelState.IsValid)
            {
                if (markaResim != null && markaResim.Length > 0)
                {
                    // Resmi yükle
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/marka", markaResim.FileName);

                    // Resmi kaydet
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await markaResim.CopyToAsync(stream);
                    }

                    // MarkaResim alanını veritabanına kaydet
                    marka.MarkaResim = "/uploads/marka/" + markaResim.FileName;
                }

                // Diğer alanları kaydet
                marka.MarkaOlusturulmaTarihi = DateTime.Now;

                // Veritabanına kaydet
                _context.Marka.Add(marka);
                await _context.SaveChangesAsync();

                return RedirectToAction("MarkaListe");
            }

            return View(marka);
        }

        // Marka Düzenleme Sayfasını Getir
        [HttpGet]
        public IActionResult MarkaDuzenle(int id)
        {
            // Markayı ID'ye göre veritabanından bul
            var marka = _context.Marka.FirstOrDefault(m => m.MarkaID == id);
            if (marka == null)
            {
                return NotFound();
            }

            // Marka verisi view'a gönderilir
            return View(marka);
        }

        // Marka Düzenleme İşlemini Yap
        [HttpPost]
        public IActionResult MarkaDuzenle(Marka marka, IFormFile markaResim)
        {
            if (ModelState.IsValid)
            {
                // ID'ye göre mevcut markayı veritabanından bul
                var mevcutMarka = _context.Marka.Find(marka.MarkaID);
                if (mevcutMarka != null)
                {
                    // Marka adı ve durumu güncelleniyor
                    mevcutMarka.MarkaAd = marka.MarkaAd;
                    mevcutMarka.MarkaDurumu = marka.MarkaDurumu;

                    // Eğer yeni bir resim yüklenmişse, mevcut resmi güncelle
                    if (markaResim != null && markaResim.Length > 0)
                    {
                        // Eski resmi silmek isterseniz:
                        // var eskiResimYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "marka", mevcutMarka.MarkaResim);
                        // if (System.IO.File.Exists(eskiResimYolu))
                        // {
                        //     System.IO.File.Delete(eskiResimYolu);
                        // }

                        // Yeni resim için yeni bir isim oluştur
                        var resimAdi = Guid.NewGuid().ToString() + Path.GetExtension(markaResim.FileName);
                        var resimYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "marka", resimAdi);

                        // Yeni resmi kaydet
                        using (var stream = new FileStream(resimYolu, FileMode.Create))
                        {
                            markaResim.CopyTo(stream);
                        }

                        // Yeni resmi veritabanında güncelle
                        mevcutMarka.MarkaResim = resimAdi;
                    }

                    // Veritabanında güncellemeyi yap
                    _context.Marka.Update(mevcutMarka);
                    _context.SaveChanges();
                }

                // İşlem başarılı ise listeye yönlendir
                return RedirectToAction("MarkaListe");
            }

            // Eğer model geçerli değilse, düzenleme formunu tekrar yükle
            return View(marka);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
