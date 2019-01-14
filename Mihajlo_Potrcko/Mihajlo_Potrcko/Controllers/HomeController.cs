using System.Web.Mvc;
using Mihajlo_Potrcko.Connection;

namespace Mihajlo_Potrcko.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          var tmp =   Konekcija.PKonekcija;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}