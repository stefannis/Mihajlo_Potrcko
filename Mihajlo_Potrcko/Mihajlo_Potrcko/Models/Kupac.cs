namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kupac")]
    public partial class Kupac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kupac()
        {
            Racuns = new HashSet<Racun>();
            Racuns1 = new HashSet<Racun>();
        }

        public int KupacID { get; set; }

        [Required]
        [StringLength(13)]
        public string FK_JMBG { get; set; }

        public int FK_NalogID { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public virtual Korisnik Korisnik1 { get; set; }

        public virtual Nalog Nalog { get; set; }

        public virtual Nalog Nalog1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns1 { get; set; }
    }
}
