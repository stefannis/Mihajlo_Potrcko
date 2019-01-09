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
            Zaposleni1 = new HashSet<Zaposleni>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZaposleniID { get; set; }

        public int? FK_VozacID { get; set; }

        [Required]
        [StringLength(13)]
        public string FK_JMBG { get; set; }

        public int Administrator { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        public virtual Vozac Vozac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaposleni> Zaposleni1 { get; set; }

        public virtual Zaposleni Zaposleni2 { get; set; }
    }
}
