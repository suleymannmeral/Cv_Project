using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDal;

        public MessageManager(IMessageDAL messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message t)
        {
           _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetBYID(int id)
        {
            return _messageDal.GetById(id);
         }

        public List<Message> TGetList()
        {
           return _messageDal.GetList();
        }

        public List<Message> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
