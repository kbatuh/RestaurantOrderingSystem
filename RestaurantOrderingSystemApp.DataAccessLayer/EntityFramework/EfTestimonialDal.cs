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
    public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EfTestimonialDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public List<Testimonial> GetTestimonialsByStatusTrue()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Testimonials
                .Where(x => x.Status == true)
                .ToList();
        }
    }
}
