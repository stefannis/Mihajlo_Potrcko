using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mihajlo_Potrcko.Models
{

    public abstract class View
    {
        protected View(string title,bool isAdmin)
        {
            Title = title;
            IsAdmin = isAdmin;
        }

        public bool IsAdmin { get; private set; }

        public string Title { get; set; }
    }


    public class MainView : View
    {
        public MainView():base("Main",false){}
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