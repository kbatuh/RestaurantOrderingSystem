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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Categories.Where(x => x.Status == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
