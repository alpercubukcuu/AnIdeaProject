using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Application.Interface.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll(
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true);

    T GetSingle(
       Expression<Func<T, bool>> predicate = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true);

    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
   

    #region Ekleme işlemleri
    Task<T> AddAsync(T entity);
    Task<List<T>> AddRangeAsync(List<T> entity);
    #endregion
    #region Güncelleme işlemleri
    Task<T> UpdateAsync(T entity);
    Task<bool> UpdateRangeAsync(List<T> entities);
    Task<T> UpdatePropertyAsync(T entity);
    #endregion
    #region Silme işlemleri
    Task<bool> DeleteAsync(T entity);
    Task<bool> DeleteByIdAsync(Guid Id);
    Task<bool> DeleteAllAsync(List<T> entities);
    Task<bool> DeleteAllAsync();
    #endregion
  
}
