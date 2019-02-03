using Mihajlo_Potrcko.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // Session control

        private SessionIDManager m = new SessionIDManager();

        public static Dictionary<string, SessionDataContainer> Sessions = new Dictionary<string, SessionDataContainer>();

     

        public static SessionDataContainer GetDataBySessionNumber(string sessionNumber)
        {
            var tmpSessionData = new SessionDataContainer();
            if (Sessions.TryGetValue(sessionNumber, out tmpSessionData))
            {
                return tmpSessionData;
            }
            return null;
        }

        internal static void UserLogIn(string jMBG, string sessionNumber)
        {
            var dicKeyValuePairs = Sessions.Where(dic => dic.Key.Equals(sessionNumber));
            if (dicKeyValuePairs.Count() == 1)
            {
                dicKeyValuePairs.First().Value.JMBG = jMBG;
            }
        }

        public void AddNewSessionData(string sessionNumber, SessionDataContainer sessionDataContainer)
        {
            if (Sessions.ContainsKey(sessionNumber))
            {
                Sessions.Remove(sessionNumber);
            }
            Sessions.Add(sessionNumber, sessionDataContainer);
        }

        public void Session_Start()
        {
            string sessionNumber = m.CreateSessionID(System.Web.HttpContext.Current);
            AddNewSessionData(sessionNumber, new SessionDataContainer()
            {
                pocetakSesije = DateTime.Now
            });
            Session["brojSesije"] = sessionNumber;
        }

        public void Session_End()
        {
            DateTime sessionStart;
            var sessionID = m.GetSessionID(System.Web.HttpContext.Current);
            var sessionIDIzSession = Session["brojSesije"];

            if (Sessions.ContainsKey(sessionID))
            {
                SessionDataContainer podatak;
                Sessions.TryGetValue(sessionID, out podatak);
                sessionStart = podatak.pocetakSesije;

                DateTime sessionEnd = DateTime.Now;
                TimeSpan duration = sessionEnd - sessionStart;
                Sessions.Where(a => a.Key.Equals(sessionID)).First().Value.trajanjeSesije = duration.ToString();
                // slanje bazi pre brisanja dictionary unosa
                Sessions.Remove(sessionID);

            }
            Session.Clear();
            Session.Abandon();
        }

        public static int? GetNalogID(string sessionNumber)
        {
            var tmpSessionData = new SessionDataContainer();
            if (Sessions.TryGetValue(sessionNumber, out tmpSessionData))
            {
                var db = new Potrcko();
                var tmpNalogs = db.Nalog.Where(nalog => nalog.JMBG.Equals(tmpSessionData.JMBG));

                if (tmpNalogs.Count() == 1)
                {
                    return tmpNalogs.First().NalogID;
                }
                return null;
            }
            return null;
        }

    }
}
