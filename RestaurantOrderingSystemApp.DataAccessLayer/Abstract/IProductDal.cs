using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal <Product>
    {
        List<Product> GetProductsWithCategories();
        decimal TotalProductsPrice();
        int ProductCount();
        int ProductCountByDrink();
        int ProductCountByDessert();
        decimal ProductPriceAvg();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductAvgPriceByDessert();

        decimal ProductPriceByAdanaKebap();

        decimal TotalPriceByDrinkCategory();
        decimal TotalPriceBySaladCategory();
    }
}
