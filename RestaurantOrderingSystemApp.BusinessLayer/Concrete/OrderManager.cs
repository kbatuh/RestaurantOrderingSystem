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
    public class OrderManager : IOrderService
    {

        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public Order TGetByID(int id)
        {
            return _orderDal.GetByID(id);
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public decimal TLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public List<Order> TFindList(Expression<Func<Order, bool>> expression)
        {
            return _orderDal.FindList(expression);
        }

        public List<Order> TGetOrdersWithMenuTableNames()
        {
            return _orderDal.GetOrdersWithMenuTableNames();
        }

        public Order? TFindOrderByMenuTableId(int id)
        {
            return _orderDal.FindOrderByMenuTableId(id);
        }

        public Order? TFindOrderWithMenuTableName(int id)
        {
            return _orderDal.FindOrderWithMenuTableName(id);
        }

        public void TCloseAccount(int id)
        {
            _orderDal.CloseAccount(id);
        }
    }
}
