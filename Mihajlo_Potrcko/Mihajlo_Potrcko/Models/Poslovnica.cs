namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Poslovnica")]
    public partial class Poslovnica : IComparable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poslovnica()
        {
            Artikal_U_Poslovnici = new HashSet<Artikal_U_Poslovnici>();
        }

        public int PoslovnicaID { get; set; }

        [Required]
        [StringLength(40)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(20)]
        public string Broj_telefona { get; set; }

        public int FK_PartnerID { get; set; }

        public virtual Partner Partner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artikal_U_Poslovnici> Artikal_U_Poslovnici { get; set; }

        public int CompareTo(Poslovnica drugaPoslovnica)
        {
            return this.PoslovnicaID > drugaPoslovnica.PoslovnicaID ? 1 : 0;
        }

        public int CompareTo(object obj)
        {
            return this.PoslovnicaID > ((Poslovnica)obj).PoslovnicaID ? 1 : 0;
        }
    }
}
