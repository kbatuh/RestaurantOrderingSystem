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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void AllNotificationStatusesChangeToTrue()
        {
            using var context = new RestaturantOrderingSystemContext();
            var values = context.Notifications.Where(x => x.Status == false).ToList();
            foreach (var value in values)
            {
                value.Status = true;
            }
            context.SaveChanges();
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Notifications.Where(x=>x.Status==false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Notifications.Where(x=>x.Status==false).Count(); 
        }

        public void NotificationStatusChange(int id)
        {
            using var context = new RestaturantOrderingSystemContext(); 
            var value = context.Notifications.Find(id);
            if (value != null)
            {
                value.Status = !value.Status;
                context.SaveChanges();
            }
        }
    }
}
