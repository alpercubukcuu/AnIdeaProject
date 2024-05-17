using Microsoft.AspNetCore.Mvc;

namespace CmsUI.ViewComponents
{
    public class Sidebar : ViewComponent
    {
        public IViewComponentResult Invoke(string viewName)
        {
            return View(viewName);
        }
    }
}
