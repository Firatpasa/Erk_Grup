
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblAdmin")]
    public class Admin
    {
        private int adminID;
        private string adminAd;
        private string adminSoyad;
        private string adminEPosta;
        private string adminSifre;
        private bool adminAktiflikDurumu;
        private DateTime adminGirisTarihi;
        private DateTime adminUyelikTarihi;

        [Key]
        public int AdminID { get => adminID; set => adminID = value; }

        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        [StringLength(30, ErrorMessage = "Ad alanı 30 karakteri geçemez")]
        public string AdminAd
        {
            get => adminAd ?? ""; // Null ise boş string döndür
            set => adminAd = value?.Trim(); // Null değilse, değeri temizle
        }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz")]
        [StringLength(30, ErrorMessage = "Soyad alanı 30 karakteri geçemez")]
        public string AdminSoyad
        {
            get => adminSoyad ?? ""; // Null ise boş string döndür
            set => adminSoyad = value?.Trim(); // Null değilse, değeri temizle
        }

        [Required(ErrorMessage = "E-posta alanı boş bırakılamaz")]
        [StringLength(70, ErrorMessage = "E-posta alanı 70 karakteri geçemez")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi")]
        public string AdminEPosta
        {
            get => adminEPosta ?? ""; // Null ise boş string döndür
            set => adminEPosta = value?.Trim(); // Null değilse, değeri temizle
        }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [StringLength(20, ErrorMessage = "Şifre alanı 20 karakteri geçemez")]
        public string AdminSifre
        {
            get => adminSifre ?? ""; // Null ise boş string döndür
            set => adminSifre = value?.Trim(); // Null değilse, değeri temizle
        }

        public bool AdminAktiflikDurumu { get => adminAktiflikDurumu; set => adminAktiflikDurumu = value; }
        public DateTime AdminGirisTarihi { get => adminGirisTarihi; set => adminGirisTarihi = value; }
        public DateTime AdminUyelikTarihi { get => adminUyelikTarihi; set => adminUyelikTarihi = value; }
    }
}
