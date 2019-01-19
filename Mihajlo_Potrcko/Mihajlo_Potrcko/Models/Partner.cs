namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partner")]
    public partial class Partner : IComparable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partner()
        {
            Poslovnica = new HashSet<Poslovnica>();
        }

        public int PartnerID { get; set; }

        [Required]
        [StringLength(30)]
        public string Naziv { get; set; }

        public decimal Procenat_zarade { get; set; }

        [Column(TypeName = "date")]
        public DateTime Datum_pocetka_poslovanja { get; set; }

        [Required]
        [StringLength(20)]
        public string Kategorija { get; set; }

        public int FK_SlikaID { get; set; }

        public virtual Slika Slika { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poslovnica> Poslovnica { get; set; }

        public int CompareTo(Partner drugiPartner)
        {
            return this.Datum_pocetka_poslovanja > drugiPartner.Datum_pocetka_poslovanja ? 1 : 0;
        }

        public int CompareTo(object obj)
        {
            
            return this.Datum_pocetka_poslovanja > ((Partner)obj).Datum_pocetka_poslovanja ? 1 : 0;
        }
    }
}
