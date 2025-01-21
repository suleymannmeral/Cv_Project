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
    public class FeatureManager : IGenericService<Feature>
    {
        IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            _featureDAL = featureDAL;
        }

        public void TAdd(Feature t)
        {
            _featureDAL.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDAL.Delete(t);
        }

        public Feature TGetBYID(int id)
        {
           return _featureDAL.GetById(id);
        }

        public List<Feature> TGetList()
        {
           return _featureDAL.GetList();
        }

        public List<Feature> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Feature t)
        {
           _featureDAL.Update(t);
        }
    }
}
