using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : DomainBase<TKey>
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add<T>(entity);
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }
    }
}