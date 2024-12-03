using Erk.DTO.Entities;
using Erk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Erk.Controllers
{
    public class IlceController : Controller
    {
        private readonly ErkDbContext _context;

        public IlceController(ErkDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        // İlçe Ekleme Sayfası (GET)
        public IActionResult IlceEkle()
        {
            var viewModel = new IlceViewModel
            {
                Ilce = new Ilce(),
                Iller = _context.Il.ToList() // Iller listesini alıyoruz
            };

            if (viewModel.Iller == null || !viewModel.Iller.Any())
            {
                // Eğer Iller listesi boşsa veya veri yoksa
                ModelState.AddModelError("", "İl listesi boş.");
                return View(viewModel);
            }

            return View(viewModel);
        }

        // İlçe Ekleme İşlemi (POST)
        [HttpPost]
        public IActionResult IlceEkle(IlceViewModel ilceViewModel)
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse tekrar view'e döneriz
                return View(ilceViewModel);
            }

            if (ilceViewModel == null || ilceViewModel.Ilce == null || ilceViewModel.Ilce.IlId <= 0)
            {
                ModelState.AddModelError("", "Geçersiz il veya ilçe bilgisi.");
                return View(ilceViewModel);
            }

            // İlçe ve il ilişkisini kontrol ediyoruz
            var il = _context.Il.FirstOrDefault(s => s.IlId == ilceViewModel.Ilce.IlId);
            if (il == null)
            {
                ModelState.AddModelError("", "Seçilen il bulunamadı.");
                return View(ilceViewModel);
            }

            // İlçe ekleme işlemi
            ilceViewModel.Ilce.Il = il;  // Seçilen ili ilişkilendiriyoruz
            _context.Ilce.Add(ilceViewModel.Ilce);
            _context.SaveChanges();

            return RedirectToAction("IlceListesi");  // İlçe listesine yönlendiriyoruz
        }

        // İlçe Listesi Sayfası (GET)
        public IActionResult IlceListesi()
        {
            var ilceler = _context.Ilce.Include(i => i.Il).ToList(); // İlçeleri ve ilişkili illeri getiriyoruz
            return View(ilceler);
        }
    }
}
