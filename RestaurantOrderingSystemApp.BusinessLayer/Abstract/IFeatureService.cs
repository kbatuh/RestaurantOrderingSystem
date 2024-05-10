using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        void TChangeStatus(int id);
        List<Feature> TGetFeaturesByStatusTrue();
    }
}
