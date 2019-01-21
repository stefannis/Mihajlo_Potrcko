using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mihajlo_Potrcko.Models
{
    public class MainView
    {

        protected MainView(string title)
        {
            Title = "MainView";
        }

        public string Title { get; set; }

    }

    public class MainView<T> : MainView
    {
        public MainView(T pageModel, string title) : base(title)
        {
            PageModel = pageModel;
        }

        public T PageModel { get; }
    }
}