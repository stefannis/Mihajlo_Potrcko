namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artikal_U_Poslovnici
    {
        public Artikal_U_Poslovnici()
        {

        }

        [Key]
        [Column(Order = 0)]
        public bool Stanje { get; set; }

        [Key]
        [Column(name:"FK_PoslovnicaID", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PoslovnicaID { get; set; }

        [Key]
        [Column(name:"FK_ArtikalID", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArtikalID { get; set; }

        public virtual Artikal Artikal { get; set; }

        public virtual Poslovnica Poslovnica { get; set; }
    }
}
