using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.WebUI.Dtos.OrderDetailDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.OrderDtos;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class OrderUIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderUIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var tableId = HttpContext.Session.GetInt32("MenuTableId");
            var code = HttpContext.Session.GetString("CustomerCode");
            if (tableId == null)
            {
                return RedirectToAction("Index", "Default");
            }

            var client = _httpClientFactory.CreateClient();
            var responseMessageOrderDetail = await client.GetAsync($"https://localhost:7282/api/OrderDetail/OrderDetailsByCustomerCodeWithProducts/{code}");
            if (responseMessageOrderDetail.IsSuccessStatusCode)
            {
                var jsonDataOrderDetail = await responseMessageOrderDetail.Content.ReadAsStringAsync();
                var valuesOrderDetail = JsonConvert.DeserializeObject<List<ResultOrderDetailWithProductDto>>(jsonDataOrderDetail);

                return View(valuesOrderDetail);
            }
            return View(new List<ResultOrderDetailWithProductDto>());
        }
    }
}
