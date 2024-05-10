using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Concrete
{
    public class CouponManager : ICouponService
    {
        private readonly ICouponDal _couponDal;

        public CouponManager(ICouponDal couponDal)
        {
            _couponDal = couponDal;
        }

        public int TGetAmountByCouponCode(string couponCode)
        {
            return _couponDal.GetAmountByCouponCode(couponCode);
        }

        public void TAdd(Coupon entity)
        {
            _couponDal.Add(entity);
        }

        public void TChangeStatus(int id)
        {
            _couponDal.ChangeStatus(id);
        }

        public void TDelete(Coupon entity)
        {
            _couponDal.Delete(entity);
        }

        public List<Coupon> TFindList(Expression<Func<Coupon, bool>> expression)
        {
            return _couponDal.FindList(expression);
        }

        public Coupon TGetByID(int id)
        {
            return _couponDal.GetByID(id);
        }

        public List<Coupon> TGetListAll()
        {
            return _couponDal.GetListAll();
        }

        public void TUpdate(Coupon entity)
        {
            _couponDal.Update(entity);
        }
    }
}
