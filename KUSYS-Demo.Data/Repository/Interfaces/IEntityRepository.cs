using KUSYS_Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Data.Repository.Interfaces
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetList(Expression<Func<T, bool>> Filter = null);
        List<T> GetListWithoutTask(Expression<Func<T, bool>> Filter = null);


        List<T> GetListWihEagerLoading(string eagerLoading, Expression<Func<T, bool>> Filter = null);

        List<T> EagerLoadingWithParams(Expression<Func<T, bool>> Filter = null,
            params Expression<Func<T, object>>[] paths);

        List<T> EagerLoadingParamsAndSelect(Expression<Func<T, bool>> Filter = null, Expression<Func<T, T>> FilterSelect = null,
            params Expression<Func<T, object>>[] paths);

        T Get(Expression<Func<T, bool>> Filter);
        void Add(T entity);
        void Add(List<T> entity);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
        void Delete(List<T> entity);
    }
}
