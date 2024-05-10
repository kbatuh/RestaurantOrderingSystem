﻿using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.BusinessLayer.Abstract
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        int TMenuTableCount();
        int TTotalMenuTableCount();
        void TChangeStatusOpen(int id);
        void TChangeStatusClose(int id);
    }
}
