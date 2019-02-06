using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mihajlo_Potrcko.LayoutViews
{
    public abstract class View
    {
        protected View(string title, bool isAdmin,bool picture)
        {
            Title = title;
            IsAdmin = isAdmin;
            IsPicture = picture;
        }

        public bool IsAdmin { get; private set; }

        public bool IsPicture { get; private set; }
        public string Title { get; set; }
    }

    public class MainView : View
    {
        public MainView() : base("Main", false, true) { }

        public MainView(bool picture) : base("Main", false, picture) { }
    }

    public class AdminView : View
    {
        public AdminView() : base("Admin", true,true) { }

        public AdminView(bool picture) : base("Admin", true, picture) { }
    }
}