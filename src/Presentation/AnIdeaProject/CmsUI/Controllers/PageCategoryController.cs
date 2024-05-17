using Microsoft.AspNetCore.Mvc;

namespace CmsUI.Controllers
{
    public class PageCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
