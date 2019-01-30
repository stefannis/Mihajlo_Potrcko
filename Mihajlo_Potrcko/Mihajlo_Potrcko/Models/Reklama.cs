namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reklama")]
    public partial class Reklama : Tabela
    {
        public Reklama():base("ReklamaID")
        {
        }

        public int ReklamaID { get; set; }

        [StringLength(20)]
        public string Naziv_kupca { get; set; }

        [Column(TypeName = "date")]
        public DateTime Datum_isteka { get; set; }

        public int FK_SlikaID { get; set; }

        public virtual Slika Slika { get; set; }
    }
}
