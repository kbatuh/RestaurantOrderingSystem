using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class AboutUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
