using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblServisler")]
    public class Servislerimiz
    {
        int servisID;
        string servisBaslik;
        string servisAciklama;
        string servisResim;
        DateTime servisYuklenmeTarihi;
        bool servisDurumu;
        [Key]
        public int ServisID { get => servisID; set => servisID = value; }
        [StringLength(100)]
        public string ServisBaslik { get => ServisBaslik; set => ServisBaslik = value.Trim(); }
        [StringLength(300)]
        public string ServisAciklama { get => ServisAciklama; set => ServisAciklama = value.Trim(); }
        [StringLength(maximumLength: 400)]
        public string ServisResim { get => ServisResim; set => ServisResim = value.Trim(); }
        public DateTime ServisYuklenmeTarihi { get => servisYuklenmeTarihi; set => servisYuklenmeTarihi = value; }
        public bool ServisDurumu { get => servisDurumu; set => servisDurumu = value; }
    }
}
