using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblSepetDetaylari")]
    public class SepetDetay
    {
        [Key]
        public int SepetDetayID { get; set; }

        [ForeignKey("Sepet")]
        public int SepetDetaySepetID { get; set; }

        [ForeignKey("Urun")]
        public int SepetDetayUrunII { get; set; }

        public int SepetDetayAdet { get; set; }
        public decimal SepetDetayBirimFiyat { get; set; }

        public virtual Sepet Sepet { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
