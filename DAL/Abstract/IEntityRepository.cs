﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IEntityRepository<T> where T : class, new()
    {
       // void Add(T entity);
       // void Update(T entity);
       // void Delete(T entity);
        
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);

        List<Malzeme> GetChoose(string[] Array); //malzemeyi arayacak

    }
}
