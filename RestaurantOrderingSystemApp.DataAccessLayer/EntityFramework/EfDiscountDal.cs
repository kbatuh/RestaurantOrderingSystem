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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.Discounts.Find(id);
            if (result != null)
            {
                result.Status = !result.Status;
                context.SaveChanges();
            }
        }
    }
}
