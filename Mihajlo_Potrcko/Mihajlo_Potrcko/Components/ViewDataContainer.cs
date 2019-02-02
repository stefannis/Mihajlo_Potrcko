
using Mihajlo_Potrcko.LayoutViews;

namespace Mihajlo_Potrcko.Components
{
    public class ViewDataContainer
    {
        public ViewDataContainer(dynamic pageModel, View viewData)
        {
            PageModel = pageModel;
            ViewData = viewData;
        }

        public dynamic PageModel { get; }
        public View ViewData { get; }
    }
}