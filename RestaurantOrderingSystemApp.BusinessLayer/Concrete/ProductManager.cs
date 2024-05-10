using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.EntityFramework;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public int TProductCountByDrink()
        {
            return _productDal.ProductCountByDrink();
        }

        public int TProductCountByDessert()
        {
            return _productDal.ProductCountByDessert();
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public string TProductNameByMaxPrice()
        {
            return _productDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _productDal.ProductNameByMinPrice();
        }

        public decimal TProductAvgPriceByDessert()
        {
            return _productDal.ProductAvgPriceByDessert();
        }

        public List<Product> TFindList(Expression<Func<Product, bool>> expression)
        {
            return _productDal.FindList(expression);
        }

        public decimal TProductPriceByAdanaKebap()
        {
            return _productDal.ProductPriceByAdanaKebap();  
        }

        public decimal TTotalPriceByDrinkCategory()
        {
           return _productDal.TotalPriceByDrinkCategory();  
        }

        
        public decimal TTotalPriceBySaladCategory()
        {
            return _productDal.TotalPriceBySaladCategory();
        }

        public decimal TTotalProductsPrice()
        {
            return _productDal.TotalProductsPrice();
        }
    }
}
