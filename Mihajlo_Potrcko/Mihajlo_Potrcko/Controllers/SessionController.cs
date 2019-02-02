using Mihajlo_Potrcko.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Mihajlo_Potrcko.Controllers
{
    public class SessionController : Controller
    {
        private SessionIDManager m = new SessionIDManager();

        public static Dictionary<string, SessionDataContainer> Sessions = new Dictionary<string, SessionDataContainer>();

        // GET: Sesija
        public ActionResult Index()
        {
            return View();
        }

        public SessionDataContainer GetDataBySessionNumber(string sessionNumber)
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

        public void AddNewSessionData(string sessionNumber,SessionDataContainer sessionDataContainer)
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
            AddNewSessionData(sessionNumber, new SessionDataContainer());
            Session["brojSesije"] = sessionNumber;

        }

        public void Session_End()
        {
            Session.Clear();
            Session.Abandon();
        }
    }
}