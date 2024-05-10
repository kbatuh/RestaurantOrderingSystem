using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.EntityFramework;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Concrete
{
    public class MenuTableMenager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableMenager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public MenuTable TGetByID(int id)
        {
            return _menuTableDal.GetByID(id);
        }

        public void TAdd(MenuTable entity)
        {
           _menuTableDal.Add(entity);   
        }

        public void TDelete(MenuTable entity)
        {
            _menuTableDal.Delete(entity);   
        }

        public List<MenuTable> TGetListAll()
        {
            return _menuTableDal.GetListAll();
        }

        public void TUpdate(MenuTable entity)
        {
            _menuTableDal.Update(entity);
        }

        public int TMenuTableCount()
        {
            return _menuTableDal.MenuTableCount();
        }

        public List<MenuTable> TFindList(Expression<Func<MenuTable, bool>> expression)
        {
            return _menuTableDal.FindList(expression);
        }

        public void TChangeStatusOpen(int id)
        {
            _menuTableDal.ChangeStatusOpen(id);
        }

        public void TChangeStatusClose(int id)
        {
            _menuTableDal.ChangeStatusClose(id);
        }

        public int TTotalMenuTableCount()
        {
            return _menuTableDal.TotalMenuTableCount();
        }
    }
}
