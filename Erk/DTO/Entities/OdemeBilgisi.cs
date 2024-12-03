using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblOdemeBilgileri")]
    public class OdemeBilgisi
    {
        [Key]
        public int OdemeBilgisiID { get; set; }

        [ForeignKey("Siparis")]
        public int OdemeBilgisiSiparisID { get; set; }

        [StringLength(20)]
        public string? OdemeBilgisiOdemeTuru { get; set; }

        public decimal OdemeBilgisiTutar { get; set; }

        [StringLength(15)]
        public string? OdemeBilgisiOdemeDurumu { get; set; }

        public virtual Siparis Siparis { get; set; }
    }
}
