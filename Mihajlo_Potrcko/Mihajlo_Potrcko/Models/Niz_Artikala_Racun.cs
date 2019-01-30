namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Niz_Artikala_Racun
    {
        [Key]
        public int Niz_artikla_racunID { get; set; }

        public int Kolicina { get; set; }

        [Column(name: "FK_RacunID")]
        public int RacunID { get; set; }

        [Column(name: "FK_ArtikalID")]
        public int ArtikalID { get; set; }

        public virtual Artikal Artikal { get; set; }

        public virtual Racun Racun { get; set; }
    }
}
