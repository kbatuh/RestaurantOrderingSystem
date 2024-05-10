using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.EntityFramework;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public MoneyCase TGetByID(int id)
        {
            return _moneyCaseDal.GetByID(id);
        }

        public void TAdd(MoneyCase entity)
        {
            _moneyCaseDal.Add(entity);  
        }

        public void TDelete(MoneyCase entity)
        {
           _moneyCaseDal.Delete(entity);    
        }

        public List<MoneyCase> TGetListAll()
        {
            return _moneyCaseDal.GetListAll();
        }

        public void TUpdate(MoneyCase entity)
        {
            _moneyCaseDal.Update(entity);   
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return _moneyCaseDal.TotalMoneyCaseAmount();
        }

        public List<MoneyCase> TFindList(Expression<Func<MoneyCase, bool>> expression)
        {
            return _moneyCaseDal.FindList(expression);
        }

        public void TAddToMoneyCase(decimal price)
        {
            _moneyCaseDal.AddToMoneyCase(price);
        }
    }
}
