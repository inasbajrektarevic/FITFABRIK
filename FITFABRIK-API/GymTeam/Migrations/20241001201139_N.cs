using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymTeam.Migrations
{
    /// <inheritdoc />
    public partial class N : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivGrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazivUlice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postanskiBroj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iznos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumUplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumVazenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Placanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iznos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanje", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlanIshrane",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ukupanBrojKalorija = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanIshrane", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrehrambeniArtikal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojKalorija = table.Column<int>(type: "int", nullable: false),
                    kategorija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrehrambeniArtikal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrivatniTrener",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slika = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivatniTrener", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produkt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sifraProdukta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kategorija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zemljaPorijekla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    masa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rolename = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VideoTrening",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ukupnoTrajanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTrening", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    adresaId = table.Column<int>(type: "int", nullable: false),
                    slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lokacija_Adresa_adresaId",
                        column: x => x.adresaId,
                        principalTable: "Adresa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClanarinaPlacanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clanarinaID = table.Column<int>(type: "int", nullable: false),
                    placanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanarinaPlacanje", x => x.id);
                    table.ForeignKey(
                        name: "FK_ClanarinaPlacanje_Clanarina_clanarinaID",
                        column: x => x.clanarinaID,
                        principalTable: "Clanarina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanarinaPlacanje_Placanje_placanjeID",
                        column: x => x.placanjeID,
                        principalTable: "Placanje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "planIshrane_PrehrambeniArtikal",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kolicina = table.Column<int>(type: "int", nullable: false),
                    prehrambeniArtikalID = table.Column<int>(type: "int", nullable: false),
                    planIshraneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planIshrane_PrehrambeniArtikal", x => x.id);
                    table.ForeignKey(
                        name: "FK_planIshrane_PrehrambeniArtikal_PlanIshrane_planIshraneID",
                        column: x => x.planIshraneID,
                        principalTable: "PlanIshrane",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_planIshrane_PrehrambeniArtikal_PrehrambeniArtikal_prehrambeniArtikalID",
                        column: x => x.prehrambeniArtikalID,
                        principalTable: "PrehrambeniArtikal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slikaKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.id);
                    table.ForeignKey(
                        name: "FK_KorisnickiNalog_Role_roleId",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lokacijaId = table.Column<int>(type: "int", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.id);
                    table.ForeignKey(
                        name: "FK_Korisnik_Lokacija_lokacijaId",
                        column: x => x.lokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Korisnik_Role_roleId",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_Korisnik_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cjenovnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivStavke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<float>(type: "real", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cjenovnik", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cjenovnik_Korisnik_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brojNarudzbe = table.Column<int>(type: "int", nullable: false),
                    datumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    popust = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cijena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false),
                    slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.id);
                    table.ForeignKey(
                        name: "FK_Obavijest_Korisnik_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    korisnikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaPlacanje",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    narudzbaID = table.Column<int>(type: "int", nullable: false),
                    placanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaPlacanje", x => x.id);
                    table.ForeignKey(
                        name: "FK_NarudzbaPlacanje_Narudzba_narudzbaID",
                        column: x => x.narudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaPlacanje_Placanje_placanjeID",
                        column: x => x.placanjeID,
                        principalTable: "Placanje",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduktNarudzba",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    narudzbaID = table.Column<int>(type: "int", nullable: false),
                    produktID = table.Column<int>(type: "int", nullable: false),
                    kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktNarudzba", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProduktNarudzba_Narudzba_narudzbaID",
                        column: x => x.narudzbaID,
                        principalTable: "Narudzba",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktNarudzba_Produkt_produktID",
                        column: x => x.produktID,
                        principalTable: "Produkt",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumOdrzavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trajanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lokacijaId = table.Column<int>(type: "int", nullable: false),
                    rezervacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.id);
                    table.ForeignKey(
                        name: "FK_Termin_Lokacija_lokacijaId",
                        column: x => x.lokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Termin_Rezervacija_rezervacijaId",
                        column: x => x.rezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_korisnikId",
                table: "AutentifikacijaToken",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Cjenovnik_korisnikId",
                table: "Cjenovnik",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ClanarinaPlacanje_clanarinaID",
                table: "ClanarinaPlacanje",
                column: "clanarinaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanarinaPlacanje_placanjeID",
                table: "ClanarinaPlacanje",
                column: "placanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickiNalog_roleId",
                table: "KorisnickiNalog",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_lokacijaId",
                table: "Korisnik",
                column: "lokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_roleId",
                table: "Korisnik",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_adresaId",
                table: "Lokacija",
                column: "adresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_korisnikID",
                table: "Narudzba",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaPlacanje_narudzbaID",
                table: "NarudzbaPlacanje",
                column: "narudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaPlacanje_placanjeID",
                table: "NarudzbaPlacanje",
                column: "placanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_korisnikId",
                table: "Obavijest",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_planIshrane_PrehrambeniArtikal_planIshraneID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "planIshraneID");

            migrationBuilder.CreateIndex(
                name: "IX_planIshrane_PrehrambeniArtikal_prehrambeniArtikalID",
                table: "planIshrane_PrehrambeniArtikal",
                column: "prehrambeniArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktNarudzba_narudzbaID",
                table: "ProduktNarudzba",
                column: "narudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktNarudzba_produktID",
                table: "ProduktNarudzba",
                column: "produktID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_korisnikId",
                table: "Rezervacija",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_lokacijaId",
                table: "Termin",
                column: "lokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_rezervacijaId",
                table: "Termin",
                column: "rezervacijaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "Cjenovnik");

            migrationBuilder.DropTable(
                name: "ClanarinaPlacanje");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "NarudzbaPlacanje");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "planIshrane_PrehrambeniArtikal");

            migrationBuilder.DropTable(
                name: "PrivatniTrener");

            migrationBuilder.DropTable(
                name: "ProduktNarudzba");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "VideoTrening");

            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "Placanje");

            migrationBuilder.DropTable(
                name: "PlanIshrane");

            migrationBuilder.DropTable(
                name: "PrehrambeniArtikal");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Produkt");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Adresa");
        }
    }
}
