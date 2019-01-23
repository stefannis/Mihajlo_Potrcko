using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mihajlo_Potrcko.Models
{

    public abstract class View
    {
        protected View(string title)
        {
            Title = title;
        }


        public string Title { get; set; }
    }

    public class AdminView : View
    {
        public AdminView():base("Admin"){}
    }

    public class MainView : View
    {
        public MainView():base("Main"){}
    }

    public class ViewDataContainer
    {
        public ViewDataContainer(dynamic pageModel,View viewData)
        {
            PageModel = pageModel;
            ViewData = viewData;
        }

        public dynamic PageModel { get; }
        public View ViewData { get; }
    }
}