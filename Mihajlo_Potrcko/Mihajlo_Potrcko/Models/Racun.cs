namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Racun")]
    public partial class Racun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Racun()
        {
            Niz_Artikala_Racun = new HashSet<Niz_Artikala_Racun>();
            Niz_Artikala_Racun1 = new HashSet<Niz_Artikala_Racun>();
            Reklamacijas = new HashSet<Reklamacija>();
            Reklamacijas1 = new HashSet<Reklamacija>();
        }

        public int RacunID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Datum_izdavanja { get; set; }

        public decimal Iznos { get; set; }

        public int FK_KupacID { get; set; }

        public int FK_VozacID { get; set; }

        [Required]
        [StringLength(30)]
        public string Adresa { get; set; }

        public virtual Kupac Kupac { get; set; }

        public virtual Kupac Kupac1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Niz_Artikala_Racun> Niz_Artikala_Racun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Niz_Artikala_Racun> Niz_Artikala_Racun1 { get; set; }

        public virtual Vozac Vozac { get; set; }

        public virtual Vozac Vozac1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reklamacija> Reklamacijas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reklamacija> Reklamacijas1 { get; set; }
    }
}
