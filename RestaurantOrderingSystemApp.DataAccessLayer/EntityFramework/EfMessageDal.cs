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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void AllMessageStatusesChangeToTrue()
        {
            using var context = new RestaturantOrderingSystemContext();
            var values = context.Messages.Where(x => x.Status == false).ToList();
            foreach (var value in values)
            {
                value.Status = true;
            }
            context.SaveChanges();
        }

        public List<Message> GetAllMessageByFalse()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Messages.Where(x => x.Status == false).ToList();
        }

        public int MessageCountByStatusFalse()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Messages.Where(x => x.Status == false).Count();
        }

        public void MessageStatusChange(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var value = context.Messages.Find(id);
            if (value != null)
            {
                value.Status = !value.Status;
                context.SaveChanges();
            }
        }
    }
}
