using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mihajlo_Potrcko.Models
{
    public class Home : Tabela
    {
        public Home():base("")
        {
            ListaSlika = new List<Slika>();
            ListaPoslovnica = new List<Poslovnica>();
        }

        public IEnumerable<Slika> ListaSlika { get; set; }
        public IEnumerable<Poslovnica> ListaPoslovnica { get; set; }
    }
}