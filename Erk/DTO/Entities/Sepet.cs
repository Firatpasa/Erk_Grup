using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblSepet")]
    public class Sepet
    {
        [Key]
        public int SepetID { get; set; }

        [ForeignKey("Musteri")]
        public int SepetMusteriID { get; set; }

        public DateTime SepetOlusturulmaTarihi { get; set; }
        public bool SepetAktifMi { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
