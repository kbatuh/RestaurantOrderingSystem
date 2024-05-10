using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.Abstract
{
    public interface ICouponDal : IGenericDal<Coupon>
    {
        void ChangeStatus(int id);
        int GetAmountByCouponCode(string couponCode);
    }
}
