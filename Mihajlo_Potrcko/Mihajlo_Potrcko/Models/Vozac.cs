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
            Racun = new HashSet<Racun>();
        }

        public int VozacID { get; set; }

        [Column(name: "FK_ZaposleniID")]
        public int ZaposleniID { get; set; }

        [Column(name: "FK_NalogID")]
        public int NalogID { get; set; }

        public virtual Nalog Nalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racun { get; set; }

        public virtual Zaposleni Zaposleni { get; set; }
    }
}
