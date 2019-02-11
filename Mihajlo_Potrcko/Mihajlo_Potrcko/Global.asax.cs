using Mihajlo_Potrcko.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Ajax.Utilities;
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
            lock (SessionAcessLock)
            {
                _sessions = new Dictionary<string, SessionDataContainer>();
            }
        }

        // Session control

        private SessionIDManager m = new SessionIDManager();

        private static object SessionAcessLock = new object();
        private static Dictionary<string, SessionDataContainer> _sessions;
        public static Dictionary<string, SessionDataContainer> Sessions
        {
            get
            {
                lock (SessionAcessLock)
                {
                    return _sessions;
                }
            }
        }



        public static SessionDataContainer GetDataBySessionNumber(string sessionNumber)
        {
            return Sessions.TryGetValue(sessionNumber, out var tmpSessionData) ? tmpSessionData : null;
        }

        internal static void UserLogIn(string jMBG, string sessionNumber)
        {
            var dicKeyValuePairs = Sessions.Where(dic => dic.Key.Equals(sessionNumber));
            var keyValuePairs = dicKeyValuePairs as KeyValuePair<string, SessionDataContainer>[] ?? dicKeyValuePairs.ToArray();
            if (keyValuePairs.Count() == 1)
            {
                keyValuePairs.First().Value.JMBG = jMBG;
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
            var sessionNumber = m.CreateSessionID(System.Web.HttpContext.Current);
            AddNewSessionData(sessionNumber, new SessionDataContainer()
            {
                pocetakSesije = DateTime.Now
            });
            Session["brojSesije"] = sessionNumber;
        }

        public void Session_End()
        {
            var sessionId = m.GetSessionID(System.Web.HttpContext.Current);

            if (Sessions.ContainsKey(sessionId))
            {
                Sessions.TryGetValue(sessionId, out var podatak);
                if (podatak != null)
                {
                    var sessionStart = podatak.pocetakSesije;

                    var sessionEnd = DateTime.Now;
                    var duration = sessionEnd - sessionStart;
                    Sessions.First(a => a.Key.Equals(sessionId)).Value.trajanjeSesije = duration.ToString();
                }

                // slanje bazi pre brisanja dictionary unosa
                Sessions.Remove(sessionId);

            }
            Session.Clear();
            Session.Abandon();
        }

        public static int? GetNalogId(string sessionNumber)
        {
            if (!Sessions.TryGetValue(sessionNumber, out var tmpSessionData)) return null;
            var db = new Potrcko();
            var tmpNalogs = db.Nalog.Where(nalog => nalog.JMBG.Equals(tmpSessionData.JMBG));

            if (tmpNalogs.Count() == 1)
            {
                return tmpNalogs.First().NalogID;
            }
            return null;
        }

        public static Korpa GetCurrentKorpa(string sessionNumber)
        {
            return !Sessions.TryGetValue(sessionNumber, out var tmpSessionData) ? null : tmpSessionData.korpa;
        }

        public static void SetCurrentKorpa(string sessionNumber, Korpa value)
        {
            if (Sessions.Count(session => session.Key.Equals(sessionNumber)) > 0)
            {
                Sessions.First(session => session.Key.Equals(sessionNumber)).Value.korpa.Set(value);
            }
        }
        public static void UpdateKorpa(string sessionNumber,int key, int quantity)
        {
            if (Sessions.Count(session => session.Key.Equals(sessionNumber)) <= 0) return;
            {
                Sessions.First(
                    session => session.Key.Equals(sessionNumber)).Value.korpa.SadrzajKorpe.First(
                    container => container.Key.Equals(key)).Value.IncInt.SetQuantity(quantity);
            }
        }

        public static void AddItemToCurrentKorpa(string sessionNumber, KorpaContainer value)
        {
            if (Sessions.Count(session => session.Key.Equals(sessionNumber)) <= 0) return;
            {
                if (Sessions.First(
                        session => session.Key.Equals(sessionNumber)).Value.korpa.SadrzajKorpe.First(
                        item => item.Value.KArtikal.ArtikalID.Equals(value.KArtikal.ArtikalID) &&
                                item.Value.KPartner.PartnerID.Equals(value.KPartner.PartnerID)) == null)
                {
                    Sessions.First(
                        session => session.Key.Equals(sessionNumber)).Value.korpa.SadrzajKorpe.Add(
                        new KorpaItem(Sessions.First(
                            session => session.Key.Equals(sessionNumber)).Value.korpa.IndexCounter,value));
                }
                else
                {
                    Sessions.First(
                        session => session.Key.Equals(sessionNumber)).Value.korpa.SadrzajKorpe.First(
                        item => item.Value.KArtikal.ArtikalID.Equals(value.KArtikal.ArtikalID) &&
                                item.Value.KPartner.PartnerID.Equals(value.KPartner.PartnerID)).Value.Update(value);
                }
                                      
                }
            }

        public static void DeleteFromKorpa(string sessionNumber, int index)
        {
            if (Sessions.Count(session => session.Key.Equals(sessionNumber)) <= 0) return;
            {
                Sessions.First(
                    session => session.Key.Equals(sessionNumber)).Value.korpa.Remove(index);
            }
    }
    }
}
