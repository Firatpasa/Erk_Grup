using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erk.DTO.Entities
{
    [Table("tblMarkalar")] // Veritabanındaki tablo adı
    public class Marka
    {
        // Marka ID - Birincil Anahtar
        [Key]
        public int MarkaID { get; set; }

        // Marka Adı
        [Required]
        [StringLength(100)]
        public string MarkaAd { get; set; }

        // Marka Oluşturulma Tarihi
        public DateTime MarkaOlusturulmaTarihi { get; set; }

        // Marka Durumu (Aktif/Pasif)
        public bool MarkaDurumu { get; set; }

        // Marka Resmi URL veya dosya yolu
        [StringLength(500)] // Uzunluğu 500 karakter ile sınırlıyoruz
        public string MarkaResim { get; set; }
    }
}
