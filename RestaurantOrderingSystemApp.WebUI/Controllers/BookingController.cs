using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.WebUI.Dtos.BookingDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.MailDtos;
using RestaurantOrderingSystemApp.WebUI.Services;
using System.Text;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7282/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetBookingListByStatusToIncoming()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7282/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7282/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7282/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7282/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> BookingStatusApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7282/api/Booking/BookingStatusApproved/{id}");

            var responseMessage = await client.GetAsync($"https://localhost:7282/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData);
                if (value != null)
                {
                    CreateMailDto createMailDto = new CreateMailDto()
                    {
                        ReceiverMail = value.Mail,
                        Subject = "Rezervasyon Onayı",
                        Body = $"Merhaba {value.Name}. {value.Date.ToString("d")} tarihi için " +
                        $"yapmış olduğunuz rezervasyonunuz onaylanmıştır. Yerinizi ayırdık. " +
                        $"Şimdiden iyi eğlenceler dilerim. " +
                        $"B | K Restoran"
                    };

                    EmailService.SendEmail(createMailDto);
                }
            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BookingStatusCancelled(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7282/api/Booking/BookingStatusCancelled/{id}");

            var responseMessage = await client.GetAsync($"https://localhost:7282/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultBookingDto>(jsonData);
                if (value != null)
                {
                    CreateMailDto createMailDto = new CreateMailDto()
                    {
                        ReceiverMail = value.Mail,
                        Subject = "Rezervasyon İptali",
                        Body = $"Merhaba {value.Name}. {value.Date.ToString("d")} tarihi için " +
                        $"yapmış olduğunuz rezervasyonunuz restoranımızdaki yoğunluk sebebiyle iptal edilmiştir. " +
                        $"Restoranımızı arayarak uygun bir zamanda rezervasyonunuzu oluşturabiliriz. İyi günler dilerim. " +
                        $"B | K Restoran"
                    };

                    EmailService.SendEmail(createMailDto);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingListByStatus(string description)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7282/api/Booking/GetBookingListByStatus?description={description}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                ViewBag.Description = description;
                return View(values);
            }
            return View();
        }
    }
}
