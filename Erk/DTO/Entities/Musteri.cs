using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblMusteriler")]
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }

        [StringLength(35)]
        public string MusteriAd{ get; set; } = string.Empty;

        [StringLength(35)]
        public string MusteriSoyad { get; set; } = string.Empty;

        [StringLength(100)]
        public string MusteriEPosta { get; set; } = string.Empty;

        [StringLength(30)]
        public string MusteriSifre { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Telefon { get; set; }

        public bool AktifMi { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
