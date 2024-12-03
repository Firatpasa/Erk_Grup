using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblUrunler")]
    public class Urun
    {
        int urunID;
        string urunAd;
        string urunAciklama;
        DateTime urunYuklenmeTarihi;
        bool urunDurumu;
        int urunKategoriID;
        int urunMarkaID;  // Marka ID burada UrunMarkaID olarak değiştirildi
        string urunResim;  // Resim alanı eklendi

        [Key]
        public int UrunID { get => urunID; set => urunID = value; }

        [StringLength(100)]
        public string UrunAd { get => urunAd; set => urunAd = value.Trim(); }

        [StringLength(300)]
        public string UrunAciklama { get => urunAciklama; set => urunAciklama = value.Trim(); }
        public DateTime UrunYuklenmeTarihi { get => urunYuklenmeTarihi; set => urunYuklenmeTarihi = value; }
        public bool UrunDurumu { get => urunDurumu; set => urunDurumu = value; }

        [ForeignKey(nameof(Kategori))]
        public int UrunKategoriID { get => urunKategoriID; set => urunKategoriID = value; }

        [ForeignKey(nameof(Marka))]  // Marka ile ilişkilendirme
        public int UrunMarkaID { get => urunMarkaID; set => urunMarkaID = value; }

        [StringLength(500)]  // Resim URL veya dosya yolu için uzunluk sınırlaması
        public string UrunResim { get => urunResim; set => urunResim = value.Trim(); }

        public virtual Kategori Kategori { get; set; }
        public virtual Marka Marka { get; set; }  // Marka ile ilişki kuruluyor
    }
}
