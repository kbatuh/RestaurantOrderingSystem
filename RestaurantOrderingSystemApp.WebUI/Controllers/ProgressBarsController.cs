using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    public class ProgressBarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
