using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Erk.DTO.Entities
{
    [Table("tblIletisim")]
    public class Iletisim
    {
        private int iletisimID;
        private string iletisimIsim;
        private string iletisimSoyIsim;
        private string iletisimEmailAdresi;
        private string iletisimCepTelNo;
        private string iletisimMesaj;
        private DateTime iletisimMesajGonderimTarihi;
        private bool iletisimDurumu;

        [Key]
        public int IletisimID
        {
            get => IletisimID;
            set => IletisimID = value;
        }

        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        [StringLength(30, ErrorMessage = "Ad alanı 30 karakteri geçemez")]
        public string IletisimIsim
        {
            get => iletisimIsim;
            set => iletisimIsim = value;
        }

        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz")]
        [StringLength(30, ErrorMessage = "Soyisim alanı 30 karakteri geçemez")]
        public string IletisimSoyIsim
        {
            get => iletisimSoyIsim;
            set => iletisimSoyIsim = value;
        }

        [Required(ErrorMessage = "E-posta alanı boş bırakılamaz")]
        [StringLength(70, ErrorMessage = "E-posta alanı 70 karakteri geçemez")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi")]
        public string IletisimEmailAdresi
        {
            get => iletisimEmailAdresi;
            set => iletisimEmailAdresi = value;
        }

        [Required(ErrorMessage = "Cep Telefonu alanı boş bırakılamaz")]
        [StringLength(70, ErrorMessage = "Cep Telefonu alanı 20 karakteri geçemez")]
        public string IletisimCepTelNo
        {
            get => iletisimCepTelNo;
            set => iletisimCepTelNo = value;
        }
        [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz")]
        [StringLength(400, ErrorMessage = "Mesajınız 400 karakteri geçemez")]
        public string IletisimMesaj
        {
            get => iletisimMesaj;
            set => iletisimMesaj = value;
        }

        public DateTime IletisimMesajGonderimTarihi
        {
            get => iletisimMesajGonderimTarihi;
            set => iletisimMesajGonderimTarihi = value;
        }

        public bool IletisimDurumu
        {
            get => iletisimDurumu;
            set => iletisimDurumu = value;
        }
    }
}
