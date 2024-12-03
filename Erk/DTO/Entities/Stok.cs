using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblStok")]
    public class Stok
    {
        // Stok ID'si
        [Key]
        public int StokID { get; set; }

        // Stok Kodu
        [StringLength(5)]
        [Required(ErrorMessage = "Stok Kodu boş bırakılamaz.")]
        public string StokKodu { get; set; }

        // Urun ID'si (İlgili ürünle ilişkilendirilmiş)
        [ForeignKey(nameof(Urun))]
        [Required(ErrorMessage = "Urun ID'si boş bırakılamaz.")]
        public int StokUrunID { get; set; }

        // Stok Miktarı
        [Range(0, double.MaxValue, ErrorMessage = "Stok Miktarı geçerli bir değer olmalıdır.")]
        [Required(ErrorMessage = "Stok Miktarı boş bırakılamaz.")]
        public double StokMiktari { get; set; }

        // Stok Fiyatı
        [Range(0, double.MaxValue, ErrorMessage = "Stok Fiyatı geçerli bir değer olmalıdır.")]
        [Required(ErrorMessage = "Stok Fiyatı boş bırakılamaz.")]
        public decimal StokFiyati { get; set; }

        // Stok Aktiflik Durumu
        [Required(ErrorMessage = "Stok Aktiflik Durumu boş bırakılamaz.")]
        public bool StokAktiflikDurumu { get; set; } // Bu alan eklendi

        public DateTime StokOlusturulmaTarihi { get; set; }  // Stok oluşturulma tarihi
        public DateTime? StokGuncellenmeTarihi { get; set; }  // Stok güncellenme tarihi

        // İlgili Urun ile bağlantı (ForeignKey ilişkisi)
        public virtual Urun Urun { get; set; }
    }
}
