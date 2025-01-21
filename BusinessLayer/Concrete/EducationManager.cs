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
    public class EducationManager : IGenericService<Education>

    {
        IEducationDAL _educationDAL;

        public EducationManager(IEducationDAL educationDAL)
        {
            _educationDAL = educationDAL;
        }

        public void TAdd(Education t)
        {
           _educationDAL.Insert(t);
        }

        public void TDelete(Education t)
        {
            _educationDAL.Delete(t);
        }

        public Education TGetBYID(int id)
        {
           return _educationDAL.GetById(id);
        }

        public List<Education> TGetList()
        {
            return _educationDAL.GetList();
        }

        public List<Education> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Education t)
        {
            _educationDAL.Update(t);
        }
    }
}
