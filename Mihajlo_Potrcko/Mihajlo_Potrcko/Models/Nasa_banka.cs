namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nasa_banka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nasa_banka()
        {
            Korisniks = new HashSet<Korisnik>();
            Korisniks1 = new HashSet<Korisnik>();
        }

        [Key]
        [StringLength(20)]
        public string Broj_racunaNB { get; set; }

        public decimal Stanje_racuna { get; set; }

        [Column(TypeName = "date")]
        public DateTime Poslednja_uplata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korisnik> Korisniks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korisnik> Korisniks1 { get; set; }
    }
}
