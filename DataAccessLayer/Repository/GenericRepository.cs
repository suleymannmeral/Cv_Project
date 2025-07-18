﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();

        }

        public List<T> GetbyFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
           using var c = new Context();
           var entity=c.Set<T>().Find(id);

            if(entity == null)
            {
                throw new Exception($"Entity with id {id} not found.");
            }
            else
            {
                return entity;
            }

        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();


        }

        public void Insert(T t)
        {
            using var c = new Context();
             c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
