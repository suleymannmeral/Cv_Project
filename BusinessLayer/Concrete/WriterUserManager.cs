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
    public class WriterUserManager : IWriterUserService
    {
        IWriterUserDAL _WriterUserDAL;

        public WriterUserManager(IWriterUserDAL writerUserDAL)
        {
            _WriterUserDAL = writerUserDAL;
        }

        public void TAdd(WriterUser t)
        {
            _WriterUserDAL.Insert(t);
        }

        public void TDelete(WriterUser t)
        {
            _WriterUserDAL.Delete(t);
        }

        public WriterUser TGetBYID(int id)
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> TGetList()
        {
            return _WriterUserDAL.GetList();
        }

        public List<WriterUser> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterUser t)
        {
            throw new NotImplementedException();
        }
    }
}
