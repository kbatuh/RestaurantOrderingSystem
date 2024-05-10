using Microsoft.EntityFrameworkCore;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Concrete;
using RestaurantOrderingSystemApp.DataAccessLayer.Repositories;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void ChangeDescription(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var value = context.OrderDetails
                .Where(x => x.OrderDetailID == id)
                .FirstOrDefault();
            if (value != null)
            {
                if (value.Description == "Sipariş Alındı")
                {
                    value.Description = "Sipariş Hazırlanıyor";
                }
                else if (value.Description == "Sipariş Hazırlanıyor")
                {
                    value.Description = "Sipariş Gönderildi";
                }
            }
            context.SaveChanges();
        }

        public List<OrderDetail> GetOrderDetailsByCustomerCodeWithProducts(string code)
        {
            using var context = new RestaturantOrderingSystemContext();
            var values = context.OrderDetails
                .Where(x => x.CustomerCode == code)
                .Include(y => y.Product)
                .ToList();
            return values;
        }

        public List<OrderDetail> GetOrderDetailsWithProducts(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var values = context.OrderDetails
                .Where(x => x.OrderID == id)
                .Include(y => y.Product)
                .ToList();
            return values;
        }
    }
}
