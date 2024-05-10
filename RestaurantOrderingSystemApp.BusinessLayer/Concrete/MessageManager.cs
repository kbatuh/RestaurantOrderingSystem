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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message TGetByID(int id)
        {
            return _messageDal.GetByID(id);
        }

        public void TAdd(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetListAll();
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);  
        }

        public List<Message> TFindList(Expression<Func<Message, bool>> expression)
        {
            return _messageDal.FindList(expression);
        }

        public int TMessageCountByStatusFalse()
        {
            return _messageDal.MessageCountByStatusFalse();
        }

        public List<Message> TGetAllMessageByFalse()
        {
            return _messageDal.GetAllMessageByFalse();
        }

        public void TMessageStatusChange(int id)
        {
            _messageDal.MessageStatusChange(id);
        }

        public void TAllMessageStatusesChangeToTrue()
        {
            _messageDal.AllMessageStatusesChangeToTrue();
        }
    }
}
