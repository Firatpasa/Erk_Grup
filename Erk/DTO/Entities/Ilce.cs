using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblIceler")]
    public class Ilce
    {
        [Key]
        public int IlceId { get; set; }

        [StringLength(100)]
        public string IlceAdi { get; set; } = string.Empty;

        [ForeignKey("Il")]
        public int IlId { get; set; }

        public virtual Il Il { get; set; }
    }
}
