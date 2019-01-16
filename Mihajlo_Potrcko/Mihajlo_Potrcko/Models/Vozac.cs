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
            Racuns1 = new HashSet<Racun>();
        }

        public int VozacID { get; set; }

        public int FK_ZaposleniID { get; set; }

        public int FK_NalogID { get; set; }

        public virtual Nalog Nalog { get; set; }

        public virtual Nalog Nalog1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Racun> Racuns1 { get; set; }

        public virtual Zaposleni Zaposleni { get; set; }

        public virtual Zaposleni Zaposleni1 { get; set; }
    }
}
