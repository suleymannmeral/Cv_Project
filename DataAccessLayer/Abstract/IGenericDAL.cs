﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T>GetList();
        T GetById(int id);

        List<T> GetbyFilter(Expression<Func<T, bool>> filter);
    }
}
