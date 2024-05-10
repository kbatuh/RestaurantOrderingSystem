using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOrderingSystemApp.WebUI.Dtos.CategoryDtos;
using RestaurantOrderingSystemApp.WebUI.Dtos.ProductDtos;

namespace RestaurantOrderingSystemApp.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7282/api/Product/ProductListWithCategory");
            var responseMessage2 = await client.GetAsync("https://localhost:7282/api/Category");
            if (responseMessage.IsSuccessStatusCode & responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategory>>(jsonData);
                var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
                ViewData["Category"] = values2?.ToList();
                return View(values);
            }
            return View();
        }

    }
}

