using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Mihajlo_Potrcko.Lib.Structs;

namespace Mihajlo_Potrcko.Models
{
    public class Partner
    {
        public int PartnerID { get; set; }
        public string Naziv { get; set; }
        public int ProcenatZarade { get; set; }

        public DateTime DatPocetkaPoslovanja
        {
            get
            {
                return DatPocetkaPoslovanja;

            }
            set
            {
                DatPocetkaPoslovanja = value.Date;

            }
        }

        public Kategorija Kategorija { get; set; }

        public int FK_SlikaID { get; set; }


}

}