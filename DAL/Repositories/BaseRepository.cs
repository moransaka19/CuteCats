using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Domain;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext dbContext;

        public BaseRepository(ApplicationContext context)
        {
            dbContext = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public T GetById(int id)
        {
            var item = GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                throw new NullReferenceException();
            }

            return item;
        }

        public void Add(T item)
        {
            dbContext.Add(item);
            dbContext.SaveChanges();
        }

        public virtual void Update(T item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            dbContext.Set<T>().Remove(item);
            dbContext.SaveChanges();
        }
    }
}
