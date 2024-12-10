﻿// <auto-generated />
using System;
using GymTeam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymTeam.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241126223934_migracijanova")]
    partial class migracijanova
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymTeam.LoginModels.AutentifikacijaToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ipAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("vrijednost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("GymTeam.LoginModels.KorisnickiNalog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("slikaKorisnika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("roleId");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("GymTeam.Models.Cjenovnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<float>("cijena")
                        .HasColumnType("real");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.Property<string>("nazivStavke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.ToTable("Cjenovnik");
                });

            modelBuilder.Entity("GymTeam.Models.Clanarina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumUplate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumVazenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("iznos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clanarina");
                });

            modelBuilder.Entity("GymTeam.Models.ClanarinaPlacanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("clanarinaID")
                        .HasColumnType("int");

                    b.Property<int>("placanjeID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clanarinaID");

                    b.HasIndex("placanjeID");

                    b.ToTable("ClanarinaPlacanje");
                });

            modelBuilder.Entity("GymTeam.Models.Korisnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("brojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("lokacijaId")
                        .HasColumnType("int");

                    b.Property<string>("lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<byte[]>("slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.HasIndex("lokacijaId");

                    b.HasIndex("roleId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.Narudzba", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("brojNarudzbe")
                        .HasColumnType("int");

                    b.Property<string>("cijena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnikID")
                        .HasColumnType("int");

                    b.Property<string>("popust")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("korisnikID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("GymTeam.Models.NarudzbaPlacanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("narudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("placanjeID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("narudzbaID");

                    b.HasIndex("placanjeID");

                    b.ToTable("NarudzbaPlacanje");
                });

            modelBuilder.Entity("GymTeam.Models.Obavijest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumObjave")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.Property<string>("naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.ToTable("Obavijest");
                });

            modelBuilder.Entity("GymTeam.Models.Placanje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("iznos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Placanje");
                });

            modelBuilder.Entity("GymTeam.Models.PlanIshrane", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("produktid")
                        .HasColumnType("int");

                    b.Property<int>("ukupanBrojKalorija")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("produktid");

                    b.ToTable("PlanIshrane");
                });

            modelBuilder.Entity("GymTeam.Models.PlanIshrane_PrehrambeniArtikal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<int>("planIshraneID")
                        .HasColumnType("int");

                    b.Property<int>("prehrambeniArtikalID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("planIshraneID");

                    b.HasIndex("prehrambeniArtikalID");

                    b.ToTable("planIshrane_PrehrambeniArtikal");
                });

            modelBuilder.Entity("GymTeam.Models.PrehrambeniArtikal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("brojKalorija")
                        .HasColumnType("int");

                    b.Property<string>("kategorija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PrehrambeniArtikal");
                });

            modelBuilder.Entity("GymTeam.Models.PrivatniTrener", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("PrivatniTrener");
                });

            modelBuilder.Entity("GymTeam.Models.Produkt", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cijena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kategorija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("masa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sifraProdukta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zemljaPorijekla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("GymTeam.Models.ProduktNarudzba", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("kolicina")
                        .HasColumnType("int");

                    b.Property<int>("narudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("produktID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("narudzbaID");

                    b.HasIndex("produktID");

                    b.ToTable("ProduktNarudzba");
                });

            modelBuilder.Entity("GymTeam.Models.Rezervacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumRezervacije")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("korisnikId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("GymTeam.Models.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Rolename")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("GymTeam.Models.Termin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("datumOdrzavanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("lokacijaId")
                        .HasColumnType("int");

                    b.Property<int>("privatnitrenerid")
                        .HasColumnType("int");

                    b.Property<int>("rezervacijaId")
                        .HasColumnType("int");

                    b.Property<string>("trajanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("lokacijaId");

                    b.HasIndex("privatnitrenerid");

                    b.HasIndex("rezervacijaId");

                    b.ToTable("Termin");
                });

            modelBuilder.Entity("GymTeam.Models.VideoTrening", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("privatnitrenerid")
                        .HasColumnType("int");

                    b.Property<string>("ukupnoTrajanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("privatnitrenerid");

                    b.ToTable("VideoTrening");
                });

            modelBuilder.Entity("GymTeam.Moduls.Adresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("NazivUlice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazivGrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postanskiBroj")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Adresa");
                });

            modelBuilder.Entity("GymTeam.Moduls.Lokacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("adresaId")
                        .HasColumnType("int");

                    b.Property<double>("latitude")
                        .HasColumnType("float");

                    b.Property<double>("longitude")
                        .HasColumnType("float");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("slika")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.HasIndex("adresaId");

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("GymTeam.LoginModels.AutentifikacijaToken", b =>
                {
                    b.HasOne("GymTeam.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("GymTeam.LoginModels.KorisnickiNalog", b =>
                {
                    b.HasOne("GymTeam.Models.Role", "Uloga")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("GymTeam.Models.Cjenovnik", b =>
                {
                    b.HasOne("GymTeam.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.ClanarinaPlacanje", b =>
                {
                    b.HasOne("GymTeam.Models.Clanarina", "clanarina")
                        .WithMany()
                        .HasForeignKey("clanarinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Placanje", "placanje")
                        .WithMany()
                        .HasForeignKey("placanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clanarina");

                    b.Navigation("placanje");
                });

            modelBuilder.Entity("GymTeam.Models.Korisnik", b =>
                {
                    b.HasOne("GymTeam.Moduls.Lokacija", "lokacija")
                        .WithMany()
                        .HasForeignKey("lokacijaId");

                    b.HasOne("GymTeam.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lokacija");

                    b.Navigation("role");
                });

            modelBuilder.Entity("GymTeam.Models.Narudzba", b =>
                {
                    b.HasOne("GymTeam.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.NarudzbaPlacanje", b =>
                {
                    b.HasOne("GymTeam.Models.Narudzba", "narudzba")
                        .WithMany()
                        .HasForeignKey("narudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Placanje", "placanje")
                        .WithMany()
                        .HasForeignKey("placanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("narudzba");

                    b.Navigation("placanje");
                });

            modelBuilder.Entity("GymTeam.Models.Obavijest", b =>
                {
                    b.HasOne("GymTeam.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.PlanIshrane", b =>
                {
                    b.HasOne("GymTeam.Models.Produkt", "produkt")
                        .WithMany()
                        .HasForeignKey("produktid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("produkt");
                });

            modelBuilder.Entity("GymTeam.Models.PlanIshrane_PrehrambeniArtikal", b =>
                {
                    b.HasOne("GymTeam.Models.PlanIshrane", "planIshrane")
                        .WithMany()
                        .HasForeignKey("planIshraneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.PrehrambeniArtikal", "prehrambeniArtikal")
                        .WithMany()
                        .HasForeignKey("prehrambeniArtikalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("planIshrane");

                    b.Navigation("prehrambeniArtikal");
                });

            modelBuilder.Entity("GymTeam.Models.ProduktNarudzba", b =>
                {
                    b.HasOne("GymTeam.Models.Narudzba", "narudzba")
                        .WithMany()
                        .HasForeignKey("narudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Produkt", "produkt")
                        .WithMany()
                        .HasForeignKey("produktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("narudzba");

                    b.Navigation("produkt");
                });

            modelBuilder.Entity("GymTeam.Models.Rezervacija", b =>
                {
                    b.HasOne("GymTeam.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("GymTeam.Models.Termin", b =>
                {
                    b.HasOne("GymTeam.Moduls.Lokacija", "lokacija")
                        .WithMany()
                        .HasForeignKey("lokacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.PrivatniTrener", "privatniTrener")
                        .WithMany()
                        .HasForeignKey("privatnitrenerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymTeam.Models.Rezervacija", "rezervacija")
                        .WithMany()
                        .HasForeignKey("rezervacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lokacija");

                    b.Navigation("privatniTrener");

                    b.Navigation("rezervacija");
                });

            modelBuilder.Entity("GymTeam.Models.VideoTrening", b =>
                {
                    b.HasOne("GymTeam.Models.PrivatniTrener", "privatniTrener")
                        .WithMany()
                        .HasForeignKey("privatnitrenerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("privatniTrener");
                });

            modelBuilder.Entity("GymTeam.Moduls.Lokacija", b =>
                {
                    b.HasOne("GymTeam.Moduls.Adresa", "adresa")
                        .WithMany()
                        .HasForeignKey("adresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adresa");
                });
#pragma warning restore 612, 618
        }
    }
}
