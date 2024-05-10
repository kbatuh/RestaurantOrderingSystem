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

    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public Basket TGetByID(int id)
        {
            return _basketDal.GetByID(id);

        }
        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetListAll()
        {
            return _basketDal.GetListAll();
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity); 
        }

        public List<Basket> TGetBasketByCustomerCodeWithProductName(string code)
        {
            return _basketDal.GetBasketByCustomerCodeWithProductName(code);
        }

        public List<Basket> TFindList(Expression<Func<Basket, bool>> expression)
        {
            return _basketDal.FindList(expression);
        }

        public void TDeleteBasketByCustomerCode(string code)
        {
            _basketDal.DeleteBasketByCustomerCode(code);
        }
    }
}
