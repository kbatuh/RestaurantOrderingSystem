using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using RestaurantOrderingSystemApp.WebUI.Dtos.BasketDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.NotificationDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.OrderDetailDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.OrderDtos;
using System.Text;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
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
            var responseMessage = await client.GetAsync($"https://localhost:7282/api/Basket/GetBasketByCustomerCodeWithProductName/{code}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketWithProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(CompleteOrderDto completeOrderDto)
        {
            completeOrderDto.Status = true;

            // Order Transactions
            var client = _httpClientFactory.CreateClient();
            var responseMessageOrder = await client.GetAsync($"https://localhost:7282/api/Order/FindOrderByMenuTableId/{completeOrderDto.MenuTableID}");
            if (responseMessageOrder.IsSuccessStatusCode)
            {
                var jsonDataOrder = await responseMessageOrder.Content.ReadAsStringAsync();
                var valueOrder = JsonConvert.DeserializeObject<ResultOrderWithMenuTableNameDto>(jsonDataOrder);
                if (valueOrder == null)
                {
                    var jsonDataCreateOrder = JsonConvert.SerializeObject(new CreateOrderDto()
                    {
                        OrderDate = completeOrderDto.OrderDate,
                        TotalPrice = completeOrderDto.TotalPrice,
                        TotalDiscount = completeOrderDto.TotalDiscount,
                        FinalPrice = completeOrderDto.FinalPrice,
                        Status = completeOrderDto.Status,
                        MenuTableID = completeOrderDto.MenuTableID,
                    });
                    StringContent stringContentCreateOrder = new StringContent(jsonDataCreateOrder, Encoding.UTF8, "application/json");
                    var responseMessageCreateOrder = await client.PostAsync("https://localhost:7282/api/Order", stringContentCreateOrder);
                    if (!responseMessageCreateOrder.IsSuccessStatusCode)
                    {
                        return View();
                    }
                }
                else
                {
                    var jsonDataUpdateOrder = JsonConvert.SerializeObject(new UpdateOrderDto()
                    {
                        OrderID = valueOrder.OrderID,
                        OrderDate = valueOrder.OrderDate,
                        TotalPrice = valueOrder.TotalPrice + completeOrderDto.TotalPrice,
                        TotalDiscount = valueOrder.TotalDiscount + completeOrderDto.TotalDiscount,
                        FinalPrice = valueOrder.FinalPrice + completeOrderDto.FinalPrice,
                        Status = valueOrder.Status,
                        MenuTableID = valueOrder.MenuTableID
                    });
                    StringContent stringContentUpdateOrder = new StringContent(jsonDataUpdateOrder, Encoding.UTF8, "application/json");
                    var responseMessageUpdateOrder = await client.PutAsync("https://localhost:7282/api/Order", stringContentUpdateOrder);
                    if (!responseMessageUpdateOrder.IsSuccessStatusCode)
                    {
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }


            // Order Detail Transactions
            var responseMessageGetOrder = await client.GetAsync($"https://localhost:7282/api/Order/FindOrderByMenuTableId/{completeOrderDto.MenuTableID}");
            var jsonDataGetOrder = await responseMessageGetOrder.Content.ReadAsStringAsync();
            var valueGetOrder = JsonConvert.DeserializeObject<ResultOrderWithMenuTableNameDto>(jsonDataGetOrder);

            var responseMessageBasket = await client.GetAsync($"https://localhost:7282/api/Basket/GetBasketByCustomerCodeWithProductName/{completeOrderDto.CustomerCode}");
            if (responseMessageBasket.IsSuccessStatusCode)
            {
                var jsonDataBasket = await responseMessageBasket.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketWithProductDto>>(jsonDataBasket);
                foreach (var value in values)
                {
                    var jsonDataCreateOrderDetail = JsonConvert.SerializeObject(new CreateOrderDetailDto()
                    {
                        Count = value.Count,
                        TotalPrice = value.TotalPrice,
                        Description = "Sipariş Alındı",
                        CustomerCode = value.CustomerCode,
                        ProductID = value.ProductID,
                        OrderID = valueGetOrder.OrderID
                    });
                    StringContent stringContentCreateOrderDetail = new StringContent(jsonDataCreateOrderDetail, Encoding.UTF8, "application/json");
                    var responseMessageCreateOrderDetail = await client.PostAsync("https://localhost:7282/api/OrderDetail", stringContentCreateOrderDetail);
                    if (!responseMessageCreateOrderDetail.IsSuccessStatusCode)
                    {
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }

            // Basket DeleteAll Transactions
            var responseMessageDeleteBasket = await client.DeleteAsync($"https://localhost:7282/api/Basket/DeleteBasketByCustomerCode/{completeOrderDto.CustomerCode}");
            if (!responseMessageDeleteBasket.IsSuccessStatusCode)
            {
                return View();
            }

            // Notification Transactions
            var jsonDataNotification = JsonConvert.SerializeObject(new CreateNotificationDto()
            {
                IconType = "Sipariş",
                Description = $"{valueGetOrder.MenuTableName} masasına yeni sipariş verildi.",
                Date = DateTime.Now,
                Status = false
            });
            StringContent stringContentNotification = new StringContent(jsonDataNotification, Encoding.UTF8, "application/json");
            var responseMessageNotification = await client.PostAsync("https://localhost:7282/api/Notification", stringContentNotification);
            if (responseMessageNotification.IsSuccessStatusCode)
            {
                decimal discount = Convert.ToDecimal(HttpContext.Session.GetString("TotalDiscount"));
                HttpContext.Session.SetString("TotalDiscount", $"{completeOrderDto.TotalDiscount + discount}");
                Thread.Sleep(3000);
                return RedirectToAction("Index", "OrderUI");
            }

            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7282/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
    }
}
