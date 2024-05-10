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
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public OrderDetail TGetByID(int id)
        {
            return _orderDetailDal.GetByID(id); 
        }

        public void TAdd(OrderDetail entity)
        {
           _orderDetailDal.Add(entity); 
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity); 
        }

        public List<OrderDetail> TGetListAll()
        {
            return _orderDetailDal.GetListAll();    
        }

        public void TUpdate(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }

        public List<OrderDetail> TFindList(Expression<Func<OrderDetail, bool>> expression)
        {
            return _orderDetailDal.FindList(expression);
        }

        public List<OrderDetail> TGetOrderDetailsWithProducts(int id)
        {
            return _orderDetailDal.GetOrderDetailsWithProducts(id);
        }

        public void TChangeDescription(int id)
        {
            _orderDetailDal.ChangeDescription(id);
        }

        public List<OrderDetail> TGetOrderDetailsByCustomerCodeWithProducts(string code)
        {
            return _orderDetailDal.GetOrderDetailsByCustomerCodeWithProducts(code);
        }
    }
}
