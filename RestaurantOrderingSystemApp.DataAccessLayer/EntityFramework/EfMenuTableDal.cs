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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(RestaturantOrderingSystemContext context) : base(context)
        {
        }

        public void ChangeStatusClose(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.MenuTables.Find(id);
            if (result != null)
            {
                result.Status = false;
                context.SaveChanges();
            }
        }

        public void ChangeStatusOpen(int id)
        {
            using var context = new RestaturantOrderingSystemContext();
            var result = context.MenuTables.Find(id);
            if (result != null)
            {
                result.Status = true;
                context.SaveChanges();
            }
        }

        public int MenuTableCount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.MenuTables
                .Where(x => x.Status == true)
                .Count();
        }

        public int TotalMenuTableCount()
        {
            using var context = new RestaturantOrderingSystemContext();
            return context.MenuTables
                .Count();
        }
    }
}
