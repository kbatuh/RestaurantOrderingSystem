using RestaurantOrderingSystemApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingSystemApp.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal <Message>
    {
        int MessageCountByStatusFalse();
        List<Message> GetAllMessageByFalse();
        void MessageStatusChange(int id);
        void AllMessageStatusesChangeToTrue();
    }
}
