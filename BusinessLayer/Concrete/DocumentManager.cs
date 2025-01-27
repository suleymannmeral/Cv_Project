using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DocumentManager : IDocumentService
    {
        IDocumentDAL _documentDal;

        public DocumentManager(IDocumentDAL documentDal)
        {
            _documentDal = documentDal;
        }

        public List<Documents> GetDocumentsByCourseName(string p)
        {
            return _documentDal.GetbyFilter(x => x.CourseName == p);

        }

        public void TAdd(Documents t)
        {
            _documentDal.Insert(t);
        }

        public void TDelete(Documents t)
        {
            throw new NotImplementedException();
        }

        public Documents TGetBYID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Documents> TGetList()
        {
            return _documentDal.GetList();
        }

        public List<Documents> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Documents t)
        {
            throw new NotImplementedException();
        }
    }
}
