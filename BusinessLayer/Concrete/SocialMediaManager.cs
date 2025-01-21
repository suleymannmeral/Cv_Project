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
    public class SocialMediaManager : IGenericService<SocialMedia>

    {
        ISocialMediaDAL _socialMediaManagerDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaManagerDAL)
        {
            _socialMediaManagerDAL = socialMediaManagerDAL;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaManagerDAL.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaManagerDAL.Delete(t);
        }

        public SocialMedia TGetBYID(int id)
        {
            return _socialMediaManagerDAL.GetById(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaManagerDAL.GetList();
        }

        public List<SocialMedia> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia t)
        {
           _socialMediaManagerDAL.Update(t);
        }
    }
}
