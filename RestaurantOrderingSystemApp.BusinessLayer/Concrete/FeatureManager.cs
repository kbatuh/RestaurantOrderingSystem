using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.Abstract;
using RestaurantOrderingSystemApp.DataAccessLayer.EntityFramework;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IfeatureDal _ıfeatureDal;

        public FeatureManager(IfeatureDal ıfeatureDal)
        {
            _ıfeatureDal = ıfeatureDal;
        }

        public Feature TGetByID(int id)
        {
            return _ıfeatureDal.GetByID(id);
        }

        public void TAdd(Feature entity)
        {
            _ıfeatureDal.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _ıfeatureDal.Delete(entity);
        }

        public List<Feature> TGetListAll()
        {
            return _ıfeatureDal.GetListAll();
        }

        public void TUpdate(Feature entity)
        {
            _ıfeatureDal.Update(entity);
        }

        public List<Feature> TFindList(Expression<Func<Feature, bool>> expression)
        {
            return _ıfeatureDal.FindList(expression);
        }

        public void TChangeStatus(int id)
        {
            _ıfeatureDal.ChangeStatus(id);
        }

        public List<Feature> TGetFeaturesByStatusTrue()
        {
            return _ıfeatureDal.GetFeaturesByStatusTrue();
        }
    }
}
