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
    public class PortfolioManager : IGenericService<Portfolio>
    {
        IPortofolioDAL _portofolioDAL;

        public PortfolioManager(IPortofolioDAL portofolioDAL)
        {
            _portofolioDAL = portofolioDAL;
        }

        public void TAdd(Portfolio t)
        {
           _portofolioDAL.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
           _portofolioDAL.Delete(t);
        }

        public Portfolio TGetBYID(int id)
        {
            return _portofolioDAL.GetById(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portofolioDAL.GetList();
        }

        public void TUpdate(Portfolio t)
        {
           _portofolioDAL.Update(t);
        }
    }
}
