using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblHakkimizda")]
    public class Hakkimizda
    {
        int hakkimizdaID;
        string hakkimizdaBaslik;
        string hakkimizdaAciklama;
        DateTime hakkimizdaAciklamaTarihi;
        bool hakkimizdaAciklamaDurumu;

        [Key]
        public int HakkimizdaID { get => hakkimizdaID; set => hakkimizdaID = value; }
        [StringLength(100)]
        public string HakkimizdaBaslik { get => HakkimizdaBaslik; set => HakkimizdaBaslik = value.Trim(); }
        [StringLength(200)]
        public string HakkimizdaAciklama { get => HakkimizdaAciklama; set => HakkimizdaAciklama = value.Trim(); }
        public DateTime HakkimizdaAciklamaTarihi { get => HakkimizdaAciklamaTarihi; set => HakkimizdaAciklamaTarihi = value; }
        public bool HakkimizdaAciklamaDurumu { get => HakkimizdaAciklamaDurumu; set => HakkimizdaAciklamaDurumu = value; }
    }
}
