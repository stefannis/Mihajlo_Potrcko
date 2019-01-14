namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vozac")]
    public partial class Vozac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vozac()
        {
            Racuns = new HashSet<Racun>();
            Zaposlenis = new HashSet<Zaposleni>();
        }

        public int VozacID { get; set; }

        [Required]
        [StringLength(13)]
        public string FK_JMBG { get; set; }

        public int FK_NalogID { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public virtual Nalog Nalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaposleni> Zaposlenis { get; set; }
    }
}
