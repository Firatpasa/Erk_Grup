using Erk.DTO.Entities;

namespace Erk.Models
{
    public class KategoriViewModel
    {
        public Kategori Kategoriler { get; set; }  // İlçe modelini tutar        
        public KategoriViewModel()
        {
            Kategoriler = new Kategori();
        }
    }
}
