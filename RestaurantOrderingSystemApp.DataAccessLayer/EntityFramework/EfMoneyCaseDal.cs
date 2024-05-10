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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void AddToMoneyCase(decimal price)
        {
            using var context = new RestaturantOrderingSystemContext();
            var value = context.MoneyCases.FirstOrDefault();
            if (value != null)
            {
                value.TotalAmount += price;
            }
            context.SaveChanges();
        }

        public decimal TotalMoneyCaseAmount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}
