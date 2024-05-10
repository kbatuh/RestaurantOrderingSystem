using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.Abstract
{
    public interface IOrderDetailDal : IGenericDal <OrderDetail>
    {
        List<OrderDetail> GetOrderDetailsWithProducts(int id);
        List<OrderDetail> GetOrderDetailsByCustomerCodeWithProducts(string code);
        void ChangeDescription(int id);
    }
}
