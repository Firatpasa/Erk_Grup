using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblFavoriler")]
    public class Favori
    {
        [Key]
        public int FavoriId { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriId { get; set; }

        [ForeignKey("Urun")]
        public int UrunId { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
