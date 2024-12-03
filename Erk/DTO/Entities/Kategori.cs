using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblKategoriler")]
    public class Kategori
    {

        int kategoriID;
        string kategoriAd;
        DateTime kategoriYuklenmeTarihi;
        bool kategoriDurumu;
        int kategoriUstKategoriID;

        [Key]
        public int KategoriID { get => kategoriID; set => kategoriID = value; }
        public string KategoriAd { get => kategoriAd; set => kategoriAd = value.Trim(); }
        public DateTime KategoriYuklenmeTarihi { get => kategoriYuklenmeTarihi; set => kategoriYuklenmeTarihi = value.Date; }
        public bool KategoriDurumu { get => kategoriDurumu; set => kategoriDurumu = value; }
        public int KategoriUstKategoriID { get => kategoriUstKategoriID; set => kategoriUstKategoriID = value; }
    }
}
