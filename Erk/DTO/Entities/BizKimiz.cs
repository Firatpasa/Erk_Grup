using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblBizKimiz")]
    public class BizKimiz
    {
        int bizKimizID;
        string bizKimizBaslik;
        string bizKimizAciklama;
        DateTime bizKimizAciklamaTarihi;
        bool bizKimizDurumu;

        [Key]
        public int BizKimizID { get => bizKimizID; set => bizKimizID = value; }
        [StringLength(100)]
        public string BizKimizBaslik { get => bizKimizBaslik; set => bizKimizBaslik = value.Trim(); }
        [StringLength(300)]
        public string BizKimizAciklama { get => bizKimizAciklama; set => bizKimizAciklama = value.Trim(); }
        public DateTime BizKimizAciklamaTarihi { get => bizKimizAciklamaTarihi; set => bizKimizAciklamaTarihi = value; }
        public bool BizKimizDurumu { get => BizKimizDurumu; set => BizKimizDurumu = value; }

    }
}