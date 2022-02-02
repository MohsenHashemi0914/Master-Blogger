using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Domain;

namespace Framework.Infrastructure
{
    public interface IRepository<in TKey, T> where T : DomainBase<TKey>
    {
        void Add(T entity);
        T GetBy(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}