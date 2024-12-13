using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFUSersMessagesDAL : GenericRepository<UsersMessages>, IUsersMessagesDAL
    {
        public List<UsersMessages> GetUsersMessagesWithUsers()
        {
            using(var c=new Context())
            {
                return c.UsersMessages.Include(x=>x.User).ToList();
            }
        }
    }
}
