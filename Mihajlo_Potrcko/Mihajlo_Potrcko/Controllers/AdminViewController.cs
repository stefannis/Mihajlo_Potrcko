﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mihajlo_Potrcko.Models;

namespace Mihajlo_Potrcko.Controllers
{
    public class AdminViewController : Controller
    {
        // GET: AdminView
        public ActionResult Index()
        {
            return View(new ViewDataContainer(null,new AdminView()));
        }
    }
}