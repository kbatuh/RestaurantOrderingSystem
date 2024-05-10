using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.WebUI.Dtos.BasketDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.NotificationDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.TestimonialDtos;
using System.Text;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class TestimonialUIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialUIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateTestimonialDto createTestimonialDto)
        {
            createTestimonialDto.Status = true;
            createTestimonialDto.ImageUrl = "images/user_testimonial.jpg";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7282/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // Notification Transactions
                var jsonDataNotification = JsonConvert.SerializeObject(new CreateNotificationDto()
                {
                    IconType = "Yorum",
                    Description = $"{createTestimonialDto.Name} restoranımız hakkında yorum yaptı.",
                    Date = DateTime.Now,
                    Status = false
                });
                StringContent stringContentNotification = new StringContent(jsonDataNotification, Encoding.UTF8, "application/json");
                var responseMessageNotification = await client.PostAsync("https://localhost:7282/api/Notification", stringContentNotification);
                if (responseMessageNotification.IsSuccessStatusCode)
                {
                    Thread.Sleep(3000);
                    return RedirectToAction("Index", "Default");
                }
                return View();
            }
            return View();
        }
    }
}
