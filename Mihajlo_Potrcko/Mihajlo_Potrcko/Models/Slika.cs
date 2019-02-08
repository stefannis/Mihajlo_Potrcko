namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slika")]
    public partial class Slika : IComparable
    {
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
        "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Slika()
    {
        Artikal = new HashSet<Artikal>();
        Nalog = new HashSet<Nalog>();
        Partner = new HashSet<Partner>();
        Reklama = new HashSet<Reklama>();
    }

    public int SlikaID { get; set; }

    [Required] [StringLength(100)] public string Link { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Artikal> Artikal { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Nalog> Nalog { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Partner> Partner { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Reklama> Reklama { get; set; }

    public int CompareTo(object obj)
    {
        return this.SlikaID > ((Slika) obj).SlikaID ? 1 : 0;
    }

    public int CompareTo(Slika drugaSlika)
    {
        return this.SlikaID > drugaSlika.SlikaID ? 1 : 0;
    }
    }
}
