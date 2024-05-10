using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Abstract
{
    public interface IOrderService: IGenericService<Order>
    {
        List<Order> TGetOrdersWithMenuTableNames();
        Order? TFindOrderByMenuTableId(int id);
        Order? TFindOrderWithMenuTableName(int id);
        void TCloseAccount(int id);
        int TTotalOrderCount();
        int TActiveOrderCount();
        decimal TLastOrderPrice();
        decimal TTodayTotalPrice();
    }
}
