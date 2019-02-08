namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Artikal")]
    public partial class Artikal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artikal()
        {
            Artikal_U_Poslovnici = new HashSet<Artikal_U_Poslovnici>();
            Niz_Artikala_Racun = new HashSet<Niz_Artikala_Racun>();
        }

        public int ArtikalID { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv_artikla { get; set; }

        [Required]
        [StringLength(20)]
        public string Cena_artikla { get; set; }

        [Column(name:"FK_SlikaID")]
        public int SlikaID { get; set; }

        public virtual Slika Slika { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artikal_U_Poslovnici> Artikal_U_Poslovnici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Niz_Artikala_Racun> Niz_Artikala_Racun { get; set; }
    }
}
