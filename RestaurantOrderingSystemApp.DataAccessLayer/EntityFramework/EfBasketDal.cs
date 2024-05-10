using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Concrete;
using RestaurantOrderingSystemApp.DataAccessLayer.Repositories;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void DeleteBasketByCustomerCode(string code)
        {
            using var context = new RestaturantOrderingSystemContext();
            var values = context.Baskets.Where(x => x.CustomerCode == code).ToList();
            context.RemoveRange(values);
            context.SaveChanges();
        }

        public List<Basket> GetBasketByCustomerCodeWithProductName(string code)
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Baskets.Where(x => x.CustomerCode == code).Include(y => y.Product).ToList();
        }
    }
}
