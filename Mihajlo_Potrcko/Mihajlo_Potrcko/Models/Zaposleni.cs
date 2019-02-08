namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zaposleni")]
    public partial class Zaposleni 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zaposleni()
        {
            Vozac = new HashSet<Vozac>();
            ZaposleniAdministratora = new HashSet<Zaposleni>();
        }

        public int ZaposleniID { get; set; }

        [Required]
        [StringLength(13)]
        [Column(name: "FK_JMBG")]
        public string JMBG { get; set; }

        public int Administrator { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vozac> Vozac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaposleni> ZaposleniAdministratora { get; set; }

        public virtual Zaposleni AdministratorOdZaposlenog { get; set; }
    }
}
