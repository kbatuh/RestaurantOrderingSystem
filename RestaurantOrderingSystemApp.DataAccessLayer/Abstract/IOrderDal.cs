using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal <Order>
    {
        List<Order> GetOrdersWithMenuTableNames();
        Order? FindOrderByMenuTableId(int id);
        Order? FindOrderWithMenuTableName(int id);
        void CloseAccount(int id);
        int TotalOrderCount();
        int ActiveOrderCount();
        decimal LastOrderPrice();
        decimal TodayTotalPrice();
    }
}
