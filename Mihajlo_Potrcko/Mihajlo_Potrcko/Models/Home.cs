using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mihajlo_Potrcko.Models
{
    public class Home 
    {
        public Home()
        {
            ListaPartnera = new List<Partner>();
        }
        public IEnumerable<Partner> ListaPartnera { get; set; }

    }
}