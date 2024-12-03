using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erk.Migrations
{
    /// <inheritdoc />
    public partial class InitsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAdmin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AdminSoyad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AdminEPosta = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    AdminSifre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdminAktiflikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    AdminGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminUyelikTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdmin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "tblAnasayfa",
                columns: table => new
                {
                    AnasayfaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnasayfaBaslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnasayfaAciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AnasayfaAciklamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnasayfaDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAnasayfa", x => x.AnasayfaID);
                });

            migrationBuilder.CreateTable(
                name: "tblBizKimiz",
                columns: table => new
                {
                    BizKimizID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BizKimizBaslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BizKimizAciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BizKimizAciklamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BizKimizDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBizKimiz", x => x.BizKimizID);
                });

            migrationBuilder.CreateTable(
                name: "tblHakkimizda",
                columns: table => new
                {
                    HakkimizdaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HakkimizdaBaslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HakkimizdaAciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HakkimizdaAciklamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HakkimizdaAciklamaDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHakkimizda", x => x.HakkimizdaID);
                });

            migrationBuilder.CreateTable(
                name: "tblIletisim",
                columns: table => new
                {
                    IletisimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IletisimIsim = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IletisimSoyIsim = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IletisimEmailAdresi = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IletisimCepTelNo = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IletisimMesaj = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IletisimMesajGonderimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IletisimDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIletisim", x => x.IletisimID);
                });

            migrationBuilder.CreateTable(
                name: "tblIller",
                columns: table => new
                {
                    IlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIller", x => x.IlId);
                });

            migrationBuilder.CreateTable(
                name: "tblKategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriYuklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategoriDurumu = table.Column<bool>(type: "bit", nullable: false),
                    KategoriUstKategoriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "tblMarkalar",
                columns: table => new
                {
                    MarkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MarkaOlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarkaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    MarkaResim = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMarkalar", x => x.MarkaID);
                });

            migrationBuilder.CreateTable(
                name: "tblMusteriler",
                columns: table => new
                {
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAd = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    MusteriSoyad = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    MusteriEPosta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MusteriSifre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMusteriler", x => x.MusteriID);
                });

            migrationBuilder.CreateTable(
                name: "tblServisler",
                columns: table => new
                {
                    ServisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServisBaslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServisAciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ServisResim = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ServisYuklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServisDurumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblServisler", x => x.ServisID);
                });

            migrationBuilder.CreateTable(
                name: "tblIceler",
                columns: table => new
                {
                    IlceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIceler", x => x.IlceId);
                    table.ForeignKey(
                        name: "FK_tblIceler_tblIller_IlId",
                        column: x => x.IlId,
                        principalTable: "tblIller",
                        principalColumn: "IlId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUrunler",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrunAciklama = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UrunYuklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrunDurumu = table.Column<bool>(type: "bit", nullable: false),
                    UrunKategoriID = table.Column<int>(type: "int", nullable: false),
                    UrunMarkaID = table.Column<int>(type: "int", nullable: false),
                    UrunResim = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUrunler", x => x.UrunID);
                    table.ForeignKey(
                        name: "FK_tblUrunler_tblKategoriler_UrunKategoriID",
                        column: x => x.UrunKategoriID,
                        principalTable: "tblKategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUrunler_tblMarkalar_UrunMarkaID",
                        column: x => x.UrunMarkaID,
                        principalTable: "tblMarkalar",
                        principalColumn: "MarkaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSepet",
                columns: table => new
                {
                    SepetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepetMusteriID = table.Column<int>(type: "int", nullable: false),
                    SepetOlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SepetAktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSepet", x => x.SepetID);
                    table.ForeignKey(
                        name: "FK_tblSepet_tblMusteriler_SepetMusteriID",
                        column: x => x.SepetMusteriID,
                        principalTable: "tblMusteriler",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSiparisler",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisMusteriID = table.Column<int>(type: "int", nullable: false),
                    SiparisSiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiparisToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SiparisDurum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSiparisler", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK_tblSiparisler_tblMusteriler_SiparisMusteriID",
                        column: x => x.SiparisMusteriID,
                        principalTable: "tblMusteriler",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAdres",
                columns: table => new
                {
                    AdresID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AadresMusteriID = table.Column<int>(type: "int", nullable: false),
                    DetayliAdres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AdresIlceID = table.Column<int>(type: "int", nullable: false),
                    PostaKodu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdres", x => x.AdresID);
                    table.ForeignKey(
                        name: "FK_tblAdres_tblIceler_AdresIlceID",
                        column: x => x.AdresIlceID,
                        principalTable: "tblIceler",
                        principalColumn: "IlceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAdres_tblMusteriler_AadresMusteriID",
                        column: x => x.AadresMusteriID,
                        principalTable: "tblMusteriler",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblFavoriler",
                columns: table => new
                {
                    FavoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFavoriler", x => x.FavoriId);
                    table.ForeignKey(
                        name: "FK_tblFavoriler_tblMusteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "tblMusteriler",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFavoriler_tblUrunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "tblUrunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblStok",
                columns: table => new
                {
                    StokID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokKodu = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StokUrunID = table.Column<int>(type: "int", nullable: false),
                    StokMiktari = table.Column<double>(type: "float", nullable: false),
                    StokFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokAktiflikDurumu = table.Column<bool>(type: "bit", nullable: false),
                    StokOlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StokGuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStok", x => x.StokID);
                    table.ForeignKey(
                        name: "FK_tblStok_tblUrunler_StokUrunID",
                        column: x => x.StokUrunID,
                        principalTable: "tblUrunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUrunResimleri",
                columns: table => new
                {
                    UrunResimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunResimUrunID = table.Column<int>(type: "int", nullable: false),
                    UrunResimResimYolu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UrunResimVarsayilanMi = table.Column<bool>(type: "bit", nullable: false),
                    UrunResimEklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUrunResimleri", x => x.UrunResimID);
                    table.ForeignKey(
                        name: "FK_tblUrunResimleri_tblUrunler_UrunResimUrunID",
                        column: x => x.UrunResimUrunID,
                        principalTable: "tblUrunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSepetDetaylari",
                columns: table => new
                {
                    SepetDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepetDetaySepetID = table.Column<int>(type: "int", nullable: false),
                    SepetDetayUrunII = table.Column<int>(type: "int", nullable: false),
                    SepetDetayAdet = table.Column<int>(type: "int", nullable: false),
                    SepetDetayBirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSepetDetaylari", x => x.SepetDetayID);
                    table.ForeignKey(
                        name: "FK_tblSepetDetaylari_tblSepet_SepetDetaySepetID",
                        column: x => x.SepetDetaySepetID,
                        principalTable: "tblSepet",
                        principalColumn: "SepetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSepetDetaylari_tblUrunler_SepetDetayUrunII",
                        column: x => x.SepetDetayUrunII,
                        principalTable: "tblUrunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOdemeBilgileri",
                columns: table => new
                {
                    OdemeBilgisiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdemeBilgisiSiparisID = table.Column<int>(type: "int", nullable: false),
                    OdemeBilgisiOdemeTuru = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OdemeBilgisiTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdemeBilgisiOdemeDurumu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOdemeBilgileri", x => x.OdemeBilgisiID);
                    table.ForeignKey(
                        name: "FK_tblOdemeBilgileri_tblSiparisler_OdemeBilgisiSiparisID",
                        column: x => x.OdemeBilgisiSiparisID,
                        principalTable: "tblSiparisler",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSiparisDetaylari",
                columns: table => new
                {
                    SiparisDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisDetaySiparisID = table.Column<int>(type: "int", nullable: false),
                    SiparisDetayUrunID = table.Column<int>(type: "int", nullable: false),
                    SiparisDetayAdet = table.Column<int>(type: "int", nullable: false),
                    SiparisDetayBirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSiparisDetaylari", x => x.SiparisDetayID);
                    table.ForeignKey(
                        name: "FK_tblSiparisDetaylari_tblSiparisler_SiparisDetaySiparisID",
                        column: x => x.SiparisDetaySiparisID,
                        principalTable: "tblSiparisler",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSiparisDetaylari_tblUrunler_SiparisDetayUrunID",
                        column: x => x.SiparisDetayUrunID,
                        principalTable: "tblUrunler",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAdres_AadresMusteriID",
                table: "tblAdres",
                column: "AadresMusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAdres_AdresIlceID",
                table: "tblAdres",
                column: "AdresIlceID");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavoriler_MusteriId",
                table: "tblFavoriler",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavoriler_UrunId",
                table: "tblFavoriler",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_tblIceler_IlId",
                table: "tblIceler",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOdemeBilgileri_OdemeBilgisiSiparisID",
                table: "tblOdemeBilgileri",
                column: "OdemeBilgisiSiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSepet_SepetMusteriID",
                table: "tblSepet",
                column: "SepetMusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSepetDetaylari_SepetDetaySepetID",
                table: "tblSepetDetaylari",
                column: "SepetDetaySepetID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSepetDetaylari_SepetDetayUrunII",
                table: "tblSepetDetaylari",
                column: "SepetDetayUrunII");

            migrationBuilder.CreateIndex(
                name: "IX_tblSiparisDetaylari_SiparisDetaySiparisID",
                table: "tblSiparisDetaylari",
                column: "SiparisDetaySiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSiparisDetaylari_SiparisDetayUrunID",
                table: "tblSiparisDetaylari",
                column: "SiparisDetayUrunID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSiparisler_SiparisMusteriID",
                table: "tblSiparisler",
                column: "SiparisMusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStok_StokUrunID",
                table: "tblStok",
                column: "StokUrunID");

            migrationBuilder.CreateIndex(
                name: "IX_tblUrunler_UrunKategoriID",
                table: "tblUrunler",
                column: "UrunKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_tblUrunler_UrunMarkaID",
                table: "tblUrunler",
                column: "UrunMarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblUrunResimleri_UrunResimUrunID",
                table: "tblUrunResimleri",
                column: "UrunResimUrunID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAdmin");

            migrationBuilder.DropTable(
                name: "tblAdres");

            migrationBuilder.DropTable(
                name: "tblAnasayfa");

            migrationBuilder.DropTable(
                name: "tblBizKimiz");

            migrationBuilder.DropTable(
                name: "tblFavoriler");

            migrationBuilder.DropTable(
                name: "tblHakkimizda");

            migrationBuilder.DropTable(
                name: "tblIletisim");

            migrationBuilder.DropTable(
                name: "tblOdemeBilgileri");

            migrationBuilder.DropTable(
                name: "tblSepetDetaylari");

            migrationBuilder.DropTable(
                name: "tblServisler");

            migrationBuilder.DropTable(
                name: "tblSiparisDetaylari");

            migrationBuilder.DropTable(
                name: "tblStok");

            migrationBuilder.DropTable(
                name: "tblUrunResimleri");

            migrationBuilder.DropTable(
                name: "tblIceler");

            migrationBuilder.DropTable(
                name: "tblSepet");

            migrationBuilder.DropTable(
                name: "tblSiparisler");

            migrationBuilder.DropTable(
                name: "tblUrunler");

            migrationBuilder.DropTable(
                name: "tblIller");

            migrationBuilder.DropTable(
                name: "tblMusteriler");

            migrationBuilder.DropTable(
                name: "tblKategoriler");

            migrationBuilder.DropTable(
                name: "tblMarkalar");
        }
    }
}
