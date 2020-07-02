using System.Collections.Generic;
using ETicaret.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq; 

namespace ETicaret.Core.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected ETicaretContext Context;
        protected DbSet<T> Entity;
        public BaseRepository(ETicaretContext context)
        {
            Context = context;
            Entity = context.Set<T>();
        }
        public void Update(T entity)
        {
            Context.Update(entity);
        }

        public void Insert(T entity)
        {
            Context.Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public IEnumerable<T> Get()
        {
            return Entity.ToList();
        }

        public T Get(int id)
        {
            return Entity.Find(id);
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }


    }
}
