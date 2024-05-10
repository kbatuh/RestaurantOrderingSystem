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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.Bookings.Find(id);
            result.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.Bookings.Find(id);
            result.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }

        public int TotalBookingCount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Bookings
                .Count();
        }
    }
}
