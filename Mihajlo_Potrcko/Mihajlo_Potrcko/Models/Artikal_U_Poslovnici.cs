namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artikal_U_Poslovnici
    {
        [Key]
        [Column(Order = 0)]
        public bool Stanje { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_PoslovnicaID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_ArtikalID { get; set; }

        public virtual Artikal Artikal { get; set; }

        public virtual Artikal Artikal1 { get; set; }

        public virtual Poslovnica Poslovnica { get; set; }

        public virtual Poslovnica Poslovnica1 { get; set; }
    }
}
