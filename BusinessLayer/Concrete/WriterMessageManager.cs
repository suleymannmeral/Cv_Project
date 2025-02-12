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
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDAL _writerMessageDAL;

        public WriterMessageManager(IWriterMessageDAL writerMessageDAL)
        {
            _writerMessageDAL = writerMessageDAL;
        }

        public List<WriterMessage> GetListReceiverList(string p)
        {
            return _writerMessageDAL.GetbyFilter(x => x.Receiver == p).OrderByDescending(x=>x.WriterMessageID).ToList();

        }

        public List<WriterMessage> GetListSenderList(string p)
        {
            return _writerMessageDAL.GetbyFilter(x => x.Sender == p);
        }

        public void TAdd(WriterMessage t)
        {
           _writerMessageDAL.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
             _writerMessageDAL.Delete(t);
        }

        public WriterMessage TGetBYID(int id)
        {
            return _writerMessageDAL.GetById(id);
        }

        public List<WriterMessage> TGetList()
        {
            throw new NotImplementedException();
        }

     

        public List<WriterMessage> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
