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
    public class UsersMessagesManager : IUsersMessagesService
    {
        IUsersMessagesDAL _userMessagesDAL;

        public UsersMessagesManager(IUsersMessagesDAL userMessagesDAL)
        {
            _userMessagesDAL = userMessagesDAL;
        }

        public List<UsersMessages> GetUsersMessagesWithUsersService()
        {
           return  _userMessagesDAL.GetUsersMessagesWithUsers();
        }

        public void TAdd(UsersMessages t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(UsersMessages t)
        {
            throw new NotImplementedException();
        }

        public UsersMessages TGetBYID(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsersMessages> TGetList()
        {
            return _userMessagesDAL.GetList();
        }

        public List<UsersMessages> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(UsersMessages t)
        {
            throw new NotImplementedException();
        }
    }
}
