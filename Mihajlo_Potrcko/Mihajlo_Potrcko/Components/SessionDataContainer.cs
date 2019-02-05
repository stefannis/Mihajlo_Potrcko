using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Components
{
    public class SessionDataContainer
    {
        public string JMBG { get; set; }
        public DateTime pocetakSesije { get; set; }

        public string trajanjeSesije { get; set; }

        public Korpa korpa;

        public SessionDataContainer()
        {
            JMBG = "";
            pocetakSesije = new DateTime();
            trajanjeSesije = "";
            korpa = new Korpa();
        }
    }
}