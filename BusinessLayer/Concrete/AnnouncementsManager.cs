﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementsManager : IGenericService<Announcements>
    {
        IAnnouncementsDAL _announcementsDAL;

        public AnnouncementsManager(IAnnouncementsDAL announcementsDAL)
        {
            _announcementsDAL = announcementsDAL;
        }

        public void TAdd(Announcements t)
        {
           _announcementsDAL.Insert(t);
        }

        public void TDelete(Announcements t)
        {
           _announcementsDAL.Delete(t);
        }

        public Announcements TGetBYID(int id)
        {
            return _announcementsDAL.GetById(id);
        }

        public List<Announcements> TGetList()
        {
            return _announcementsDAL.GetList();
        }

        public List<Announcements> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcements t)
        {
            throw new NotImplementedException();
        }
    }
}
