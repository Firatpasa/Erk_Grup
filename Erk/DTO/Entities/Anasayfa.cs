using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblAnasayfa")]
    public class Anasayfa
    {
        int anasayfaID;
        string anasayfaBaslik;
        string anasayfaAciklama;
        DateTime anasayfaAciklamaTarihi;
        bool anasayfaDurumu;

        [Key]
        public int AnasayfaID { get => anasayfaID; set => anasayfaID = value; }
        [StringLength(100)]
        public string AnasayfaBaslik { get => anasayfaBaslik; set => anasayfaBaslik = value.Trim(); }
        [StringLength(300)]
        public string AnasayfaAciklama { get => anasayfaAciklama; set => anasayfaAciklama = value.Trim(); }
        public DateTime AnasayfaAciklamaTarihi { get => anasayfaAciklamaTarihi; set => anasayfaAciklamaTarihi = value; }
        public bool AnasayfaDurumu { get => anasayfaDurumu; set => anasayfaDurumu = value; }


    }
}
