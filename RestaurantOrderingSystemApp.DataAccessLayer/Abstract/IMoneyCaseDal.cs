﻿using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.Abstract
{
    public interface IMoneyCaseDal : IGenericDal <MoneyCase>
    {
        decimal TotalMoneyCaseAmount();
        void AddToMoneyCase(decimal price);
    }
}
