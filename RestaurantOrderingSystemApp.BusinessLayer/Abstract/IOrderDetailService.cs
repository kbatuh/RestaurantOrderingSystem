using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Abstract
{
    public interface IOrderDetailService : IGenericService<OrderDetail> 
    {
        List<OrderDetail> TGetOrderDetailsWithProducts(int id);
        List<OrderDetail> TGetOrderDetailsByCustomerCodeWithProducts(string code);
        void TChangeDescription(int id);
    }
}
