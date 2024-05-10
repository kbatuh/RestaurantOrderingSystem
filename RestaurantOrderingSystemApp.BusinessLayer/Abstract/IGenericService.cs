using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);
        void TDelete(T entity);

        void TUpdate(T entity);
        T TGetByID(int id);

        List<T> TGetListAll();
        List<T> TFindList(Expression<Func<T, bool>> expression);
    }
}
