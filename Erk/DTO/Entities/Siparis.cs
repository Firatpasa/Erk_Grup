using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblSiparisler")]
    public class Siparis
    {
        [Key]
        public int SiparisID { get; set; }

        [ForeignKey("Musteri")]
        public int SiparisMusteriID { get; set; }

        public DateTime SiparisSiparisTarihi { get; set; }
        public decimal SiparisToplamTutar { get; set; }

        public SiparisDurumu? SiparisDurum { get; set; }

        public virtual Musteri Musteri { get; set; }
    }

    public enum SiparisDurumu
    {
        Bekliyor,
        Hazirlaniyor,
        Gonderildi,
        Tamamlandi
    }
}

