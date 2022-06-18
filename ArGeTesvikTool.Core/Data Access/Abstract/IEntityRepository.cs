using ArGeTesvikTool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ArGeTesvikTool.Core.Data_Access
{
    public interface IEntityRepository<T>
        where T : class, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void AddList(List<T> entity);
        void Add(T entity);
        void Update(T entity);
        void UpdateList(List<T> entity);
        void Delete(T entity);
        void DeleteList(List<T> entity);
    }
}
