using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using RestaurantOrderingSystemApp.WebUI.Dtos.OrderDetailDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.OrderDtos;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageOrderDetail = await client.GetAsync($"https://localhost:7282/api/OrderDetail/OrderDetailListWithProduct/{id}");
            if (responseMessageOrderDetail.IsSuccessStatusCode)
            {
                var jsonDataOrderDetail = await responseMessageOrderDetail.Content.ReadAsStringAsync();
                var valuesOrderDetail = JsonConvert.DeserializeObject<List<ResultOrderDetailWithProductDto>>(jsonDataOrderDetail);

                var responseMessageOrder = await client.GetAsync($"https://localhost:7282/api/Order/FindOrderWithMenuTableName/{id}");
                var jsonDataOrder = await responseMessageOrder.Content.ReadAsStringAsync();
                var valueOrder = JsonConvert.DeserializeObject<ResultOrderWithMenuTableNameDto>(jsonDataOrder);

                return View(Tuple.Create(valuesOrderDetail, valueOrder));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ChangeDescription(int id, int orderId)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7282/api/OrderDetail/ChangeDescription/{id}");
            return Redirect("/OrderDetail/GetOrderDetail/" + orderId);
        }
    }
}
