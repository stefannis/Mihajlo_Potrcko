namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Potrcko : DbContext
    {
        public Potrcko()
            : base("name=Potrcko")
        {
        }

        public virtual DbSet<Artikal> Artikal { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<Nalog> Nalog { get; set; }
        public virtual DbSet<Nasa_banka> Nasa_banka { get; set; }
        public virtual DbSet<Niz_Artikala_Racun> Niz_Artikala_Racun { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Poslovnica> Poslovnica { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<Racuni_banke> Racuni_banke { get; set; }
        public virtual DbSet<Reklama> Reklama { get; set; }
        public virtual DbSet<Reklamacija> Reklamacija { get; set; }
        public virtual DbSet<Slika> Slika { get; set; }
        public virtual DbSet<Vozac> Vozac { get; set; }
        public virtual DbSet<Zaposleni> Zaposleni { get; set; }
        public virtual DbSet<Artikal_U_Poslovnici> Artikal_U_Poslovnici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikal>()
                .Property(e => e.Naziv_artikla)
                .IsUnicode(false);

            modelBuilder.Entity<Artikal>()
                .Property(e => e.Cena_artikla)
                .IsUnicode(false);

            modelBuilder.Entity<Artikal>()
                .HasMany(e => e.Artikal_U_Poslovnici)
                .WithRequired(e => e.Artikal)
                .HasForeignKey(e => e.ArtikalID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artikal>()
                .HasMany(e => e.Niz_Artikala_Racun)
                .WithRequired(e => e.Artikal)
                .HasForeignKey(e => e.ArtikalID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Prezime)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Broj_RacunaNB)
                .IsUnicode(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Kupac)
                .WithRequired(e => e.Korisnik)
                .HasForeignKey(e => e.JMBG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Nalog)
                .WithRequired(e => e.Korisnik)
                .HasForeignKey(e => e.JMBG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Racuni_banke)
                .WithRequired(e => e.Korisnik)
                .HasForeignKey(e => e.JMBG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Zaposleni)
                .WithRequired(e => e.Korisnik)
                .HasForeignKey(e => e.JMBG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kupac>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<Kupac>()
                .HasMany(e => e.Racun)
                .WithRequired(e => e.Kupac)
                .HasForeignKey(e => e.KupacID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nalog>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Nalog>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Nalog>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<Nalog>()
                .HasMany(e => e.Kupac)
                .WithRequired(e => e.Nalog)
                .HasForeignKey(e => e.NalogID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nalog>()
                .HasMany(e => e.Vozac)
                .WithRequired(e => e.Nalog)
                .HasForeignKey(e => e.NalogID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nasa_banka>()
                .Property(e => e.Broj_racunaNB)
                .IsUnicode(false);

            modelBuilder.Entity<Nasa_banka>()
                .Property(e => e.Stanje_racuna)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Nasa_banka>()
                .HasMany(e => e.Korisnik)
                .WithRequired(e => e.Nasa_banka)
                .HasForeignKey(e => e.Broj_RacunaNB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Procenat_zarade)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Partner>()
                .Property(e => e.Kategorija)
                .IsUnicode(false);

            modelBuilder.Entity<Partner>()
                .HasMany(e => e.Poslovnica)
                .WithRequired(e => e.Partner)
                .HasForeignKey(e => e.PartnerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Poslovnica>()
                .Property(e => e.Adresa)
                .IsUnicode(false);

            modelBuilder.Entity<Poslovnica>()
                .Property(e => e.Broj_telefona)
                .IsUnicode(false);

            modelBuilder.Entity<Poslovnica>()
                .HasMany(e => e.Artikal_U_Poslovnici)
                .WithRequired(e => e.Poslovnica)
                .HasForeignKey(e => e.PoslovnicaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Racun>()
                .Property(e => e.Iznos)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Racun>()
                .Property(e => e.Adresa)
                .IsUnicode(false);

            modelBuilder.Entity<Racun>()
                .HasMany(e => e.Niz_Artikala_Racun)
                .WithRequired(e => e.Racun)
                .HasForeignKey(e => e.RacunID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Racun>()
                .HasMany(e => e.Reklamacija)
                .WithRequired(e => e.Racun)
                .HasForeignKey(e => e.RacunID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Racuni_banke>()
                .Property(e => e.Broj_racuna)
                .IsUnicode(false);

            modelBuilder.Entity<Racuni_banke>()
                .Property(e => e.Naziv_banke)
                .IsUnicode(false);

            modelBuilder.Entity<Racuni_banke>()
                .Property(e => e.Vlasnik_racuna)
                .IsUnicode(false);

            modelBuilder.Entity<Racuni_banke>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<Reklama>()
                .Property(e => e.Naziv_kupca)
                .IsUnicode(false);

            modelBuilder.Entity<Reklamacija>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<Slika>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Slika>()
                .HasMany(e => e.Artikal)
                .WithRequired(e => e.Slika)
                .HasForeignKey(e => e.SlikaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slika>()
                .HasMany(e => e.Nalog)
                .WithRequired(e => e.Slika)
                .HasForeignKey(e => e.SlikaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slika>()
                .HasMany(e => e.Partner)
                .WithRequired(e => e.Slika)
                .HasForeignKey(e => e.SlikaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slika>()
                .HasMany(e => e.Reklama)
                .WithRequired(e => e.Slika)
                .HasForeignKey(e => e.SlikaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vozac>()
                .HasMany(e => e.Racun)
                .WithRequired(e => e.Vozac)
                .HasForeignKey(e => e.VozacID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zaposleni>()
                .Property(e => e.JMBG)
                .IsUnicode(false);

            modelBuilder.Entity<Zaposleni>()
                .HasMany(e => e.Vozac)
                .WithRequired(e => e.Zaposleni)
                .HasForeignKey(e => e.ZaposleniID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zaposleni>()
                .HasMany(e => e.Zaposleni1)
                .WithRequired(e => e.Zaposleni2)
                .HasForeignKey(e => e.Administrator);
        }
    }
}
