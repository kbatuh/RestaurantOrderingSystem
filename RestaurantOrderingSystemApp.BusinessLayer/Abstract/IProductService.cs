using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        decimal TTotalProductsPrice();
        int TProductCount();
        int TProductCountByDrink();
        int TProductCountByDessert();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductAvgPriceByDessert();
        public decimal TProductPriceByAdanaKebap();
        public decimal TTotalPriceByDrinkCategory();
        public decimal TTotalPriceBySaladCategory();
    }
}
