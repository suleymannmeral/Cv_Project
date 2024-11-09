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
    public class ContactManager : IGenericService<Contact>
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void TAdd(Contact t)
        {
            _contactDAL.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contactDAL.Delete(t);
        }

        public Contact TGetBYID(int id)
        {
            return _contactDAL.GetById(id);
        }

        public List<Contact> TGetList()
        {
            return _contactDAL.GetList();
        }

        public void TUpdate(Contact t)
        {
            _contactDAL.Update(t);
        }
    }
}
