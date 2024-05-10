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
    public class EfFeatureDal : GenericRepository<Feature>, IfeatureDal
    {
        public EfFeatureDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.Features.Find(id);
            if (result != null)
            {
                result.Status = !result.Status;
                context.SaveChanges();
            }
        }

        public List<Feature> GetFeaturesByStatusTrue()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Features
                .Where(x => x.Status == true)
                .ToList();
        }
    }
}
