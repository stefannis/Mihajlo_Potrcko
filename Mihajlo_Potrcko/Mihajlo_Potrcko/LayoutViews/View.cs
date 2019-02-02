using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mihajlo_Potrcko.LayoutViews
{
    public abstract class View
    {
        protected View(string title, bool isAdmin)
        {
            Title = title;
            IsAdmin = isAdmin;
        }

        public bool IsAdmin { get; private set; }

        public string Title { get; set; }
    }

    public class MainView : View
    {
        public MainView() : base("Main", false) { }
    }

    public class AdminView : View
    {
        public AdminView() : base("Admin", true) { }
    }
}