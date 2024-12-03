using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblSiparisDetaylari")]
    public class SiparisDetay
    {
        [Key]
        public int SiparisDetayID { get; set; }

        [ForeignKey("Siparis")]
        public int SiparisDetaySiparisID { get; set; }

        [ForeignKey("Urun")]
        public int SiparisDetayUrunID { get; set; }

        public int SiparisDetayAdet { get; set; }
        public decimal SiparisDetayBirimFiyat { get; set; }

        public virtual Siparis Siparis { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
