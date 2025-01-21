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
    public class TodolistManager : ITodolistService
    {
        ITodolistDAL _todolistmanager;

        public TodolistManager(ITodolistDAL todolistmanager)
        {
            _todolistmanager = todolistmanager;
        }

        public void TAdd(Todolist t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Todolist t)
        {
            throw new NotImplementedException();
        }

        public Todolist TGetBYID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Todolist> TGetList()
        {
            return _todolistmanager.GetList();
        }

        public List<Todolist> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Todolist t)
        {
            throw new NotImplementedException();
        }
    }
}
