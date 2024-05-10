using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.WebUI.Dtos.BookingDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.NotificationDtos;
using System.Net.Http;
using System.Text;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7282/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                // Notification Transactions
                var jsonDataNotification = JsonConvert.SerializeObject(new CreateNotificationDto()
                {
                    IconType = "Rezervasyon",
                    Description = $"{createBookingDto.Name} restoranımıza {createBookingDto.Date} tarihine {createBookingDto.PersonCount} kişilik rezervasyon oluşturdu.",
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
