using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMirror.Domain.Repositories
{
    public interface IRepository<T> where T : new()
    {
        IQueryable<T> Items { get; }

        T Create(Guid? id = null);

        void Delete(T obj);

        void Add(T obj);

        EntityState GetEntityState(T entity);

        T Find(Guid id);

        void RemoveRange(IEnumerable<T> entities);
    }
}
