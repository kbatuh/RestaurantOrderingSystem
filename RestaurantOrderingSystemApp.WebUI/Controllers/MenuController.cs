using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using RestaurantOrderingSystemApp.WebUI.Dtos.BasketDtos;
using RestaurantOrderingSystemApp.WebUI.Services;
using System.Net.Http;
using System.Text;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string mtCode = "bkrestoran")
        {
            var tableId = HttpContext.Session.GetInt32("MenuTableId");
            var menuTableId = Convert.ToInt32(AesOperation.Decode(mtCode));

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7282/api/MenuTable/{menuTableId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<MenuTable>(jsonData);

                if (value == null && tableId == null)
                {
                    return RedirectToAction("Index", "Default");
                }
                else if (value == null && menuTableId != 0 && tableId != null)
                {
                    await client.GetAsync($"https://localhost:7282/api/MenuTable/ChangeStatusClose/{HttpContext.Session.GetInt32("MenuTableId")}");
                    HttpContext.Session.Clear();
                    return RedirectToAction("Index", "Default");
                }
                else if (value != null)
                {
                    HttpContext.Session.SetInt32("MenuTableId", menuTableId);
                    HttpContext.Session.SetString("CustomerCode", Guid.NewGuid().ToString().Substring(0, 8));
                    var client2 = _httpClientFactory.CreateClient();
                    await client2.GetAsync($"https://localhost:7282/api/MenuTable/ChangeStatusOpen/{HttpContext.Session.GetInt32("MenuTableId")}");
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto createBasketDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7282/api/Basket", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
