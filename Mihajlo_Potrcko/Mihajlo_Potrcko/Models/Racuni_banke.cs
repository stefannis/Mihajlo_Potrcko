namespace Mihajlo_Potrcko.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Racuni_banke : Tabela
    {
        public Racuni_banke():base("Broj_racuna")
        {
        }

        [Key]
        [StringLength(20)]
        public string Broj_racuna { get; set; }

        [Required]
        [StringLength(20)]
        public string Naziv_banke { get; set; }

        [Required]
        [StringLength(40)]
        public string Vlasnik_racuna { get; set; }

        [Column(TypeName = "date")]
        public DateTime Datum_isteka { get; set; }

        [Required]
        [StringLength(13)]
        [Column(name: "FK_JMBG")]
        public string JMBG { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}
