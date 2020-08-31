using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Models;

namespace SmartMirror.Domain.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class, new()
    {
        protected SmartMirrorDbContext _context;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get { return _dbSet ?? (_dbSet = _context.Set<T>()); }
        }

        protected RepositoryBase(SmartMirrorDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IQueryable<T> Items { get { return DbSet; } }

        public virtual T Create(Guid? id = null)
        {
            var obj = new T();

            if (id.HasValue && obj is Entity)
                (obj as Entity).Id = id.Value;

            Add(obj);
            return obj;
        }

        public virtual void Delete(T obj)
        {
            DbSet.Remove(obj);
        }

        public virtual void Add(T obj)
        {
            DbSet.Add(obj);
        }

        public EntityState GetEntityState(T entity)
        {
            return _context.Entry(entity).State;
        }

        public T Find(Guid id)
        {
            return DbSet.Find(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
