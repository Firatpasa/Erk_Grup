using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblUrunResimleri")]
    public class UrunResim
    {
        [Key]
        public int UrunResimID { get; set; }

        [ForeignKey("Urun")]
        public int UrunResimUrunID { get; set; }

        [StringLength(500)]
        public string UrunResimResimYolu { get; set; } = string.Empty;

        public bool UrunResimVarsayilanMi { get; set; }
        public DateTime UrunResimEklenmeTarihi { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
