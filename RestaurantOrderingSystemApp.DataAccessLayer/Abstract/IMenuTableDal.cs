using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.Abstract
{
    public interface IMenuTableDal : IGenericDal <MenuTable>
    {
        int MenuTableCount();
        int TotalMenuTableCount();
        void ChangeStatusOpen(int id);
        void ChangeStatusClose(int id);
    }
}
