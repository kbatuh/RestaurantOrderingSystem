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
    public class EfCouponDal : GenericRepository<Coupon>, ICouponDal
    {
        public EfCouponDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.Coupons.Find(id);
            result.Status = !result.Status;
            context.SaveChanges();
        }

        public int GetAmountByCouponCode(string couponCode)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.Coupons
                .Where(x => x.CouponCode == couponCode)
                .Where(y => y.Status)
                .Select(z => z.Amount)
                .FirstOrDefault();
            return result;
        }
    }
}
