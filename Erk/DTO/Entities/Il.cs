using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblIller")]
    public class Il
    {
        [Key]
        public int IlId { get; set; }

        [StringLength(100)]
        public string IlAdi { get; set; } = string.Empty;
    }
}
