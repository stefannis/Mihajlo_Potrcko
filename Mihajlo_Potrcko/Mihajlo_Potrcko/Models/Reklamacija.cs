namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reklamacija")]
    public partial class Reklamacija
    {
        public int ReklamacijaID { get; set; }

        public int FK_RacunID { get; set; }

        [StringLength(256)]
        public string Opis { get; set; }

        public virtual Racun Racun { get; set; }
    }
}