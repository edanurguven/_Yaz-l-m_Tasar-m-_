using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class EfBaseRepository<T> : IEntityRepository<T>
         where T : class, new()
    {
        List<T> list = new List<T>();
        public void Add(T entity)
        {
            using (var context = new ProjeDbContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new ProjeDbContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new ProjeDbContext())
            {
                return context.Set<T>().SingleOrDefault();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new ProjeDbContext())
            {
                return filter == null ?
                    context.Set<T>().ToList() :
                    context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = new ProjeDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            using (var context = new ProjeDbContext())
            {
                return context.Find<T>(id);
            }
        }

        public List<T> GetChoose()
        {
            using (var context = new ProjeDbContext())
            {
                return context.Set<T>().ToList();

            }
        }
    }
}
