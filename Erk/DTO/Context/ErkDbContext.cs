using Microsoft.EntityFrameworkCore;

namespace Erk.DTO.Entities
{
    public class ErkDbContext : DbContext
    {
        protected ErkDbContext()
        {
        }
        public ErkDbContext(DbContextOptions<ErkDbContext> options) : base(options)
        {


        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Adres> Adres { get; set; }

        public DbSet<Anasayfa> Anasayfa { get; set; }
        public DbSet<BizKimiz> BizKimiz { get; set; }
        public DbSet<Favori> Favori { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }

        public DbSet<Il> Il { get; set; }

        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<OdemeBilgisi> OdemeBilgisi { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<SepetDetay> SepetDetay { get; set; }
        public DbSet<Servislerimiz> Servislerimiz { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisDetay> SiparisDetay { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<Urun> Urun { get; set; }

        public DbSet<UrunResim> UrunResim { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TS4MUQU;Initial Catalog=dbErk;Integrated Security=true;Encrypt=False");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-KLOEKA9\\SQLEXPRESS;Initial Catalog=OkulDbMvc;Integrated Security=true");
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OkulDbMvc;Integrated Security=true");
        }
    }
}
