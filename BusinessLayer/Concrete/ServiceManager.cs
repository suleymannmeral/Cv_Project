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
    public class ServiceManager : IGenericService<Service>
    {
        IServiceDAL _serviceDAL;

        public ServiceManager(IServiceDAL serviceDAL)
        {
            _serviceDAL = serviceDAL;
        }

        public void TAdd(Service t)
        {
            _serviceDAL.Insert(t);
        }

        public void TDelete(Service t)
        {
            _serviceDAL.Delete(t);
        }

        public Service TGetBYID(int id)
        {
           return _serviceDAL.GetById(id);
        }

        public List<Service> TGetList()
        {
            return _serviceDAL.GetList();
        }

        public void TUpdate(Service t)
        {
            _serviceDAL.Update(t);
        }
    }
}
