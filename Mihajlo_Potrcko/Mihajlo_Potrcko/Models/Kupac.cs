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
            Racun = new HashSet<Racun>();
        }

        public int KupacID { get; set; }

        [Required]
        [StringLength(13)]
        [Column(name:"FK_JMBG")]
        public string JMBG { get; set; }

        [Column(name: "FK_NalogID")]
        public int NalogID { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public virtual Nalog Nalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racun { get; set; }
    }
}
