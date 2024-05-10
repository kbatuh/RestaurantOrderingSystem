using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Concrete;
using RestaurantOrderingSystemApp.DataAccessLayer.Repositories;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            using var context = new RestaturantOrderingSystemContext();
            var values = context.Products.Include(x=>x.Category).ToList();
            return values;

        }

        public int ProductCount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Count();
        }

        public int ProductCountByDrink()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecekler").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByDessert()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Tatlılar").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Average(x => x.Price);
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductAvgPriceByDessert()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Tatlılar").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
        }

        public decimal ProductPriceByAdanaKebap()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Where(x => x.ProductName=="Adana Kebap").Select(y => y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            using var context = new RestaturantOrderingSystemContext();
            int id=context.Categories.Where(x=>x.CategoryName== "İçecekler").Select(y=>y.CategoryID).FirstOrDefault();
            return context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);   
        }

        public decimal TotalPriceBySaladCategory()
        {
            using var context = new RestaturantOrderingSystemContext();
            int id = context.Categories.Where(x => x.CategoryName == "Salatalar").Select(y => y.CategoryID).FirstOrDefault();
            return context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }

        public decimal TotalProductsPrice()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Products.Sum(y => y.Price);
        }
    }
}
