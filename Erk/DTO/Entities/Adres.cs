using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblAdres")]
    public class Adres
    {
        [Key]
        public int AdresID { get; set; }

        [ForeignKey("Musteri")]
        public int AadresMusteriID { get; set; }

        [StringLength(500)]
        public string DetayliAdres { get; set; } = string.Empty;

        [ForeignKey("Ilce")]
        public int AdresIlceID { get; set; }

        [StringLength(10)]
        public string? PostaKodu { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual Ilce Ilce { get; set; }
    }
}
