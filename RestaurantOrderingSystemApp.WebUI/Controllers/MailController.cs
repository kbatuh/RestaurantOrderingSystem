using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.WebUI.Dtos.MailDtos;
using RestaurantOrderingSystemApp.WebUI.Services;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            EmailService.SendEmail(createMailDto);
            return RedirectToAction("Index", "Category");   
        }
    }
}
