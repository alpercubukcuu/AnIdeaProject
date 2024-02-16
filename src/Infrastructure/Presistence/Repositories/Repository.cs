using Application.Interface.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Context;
using System.Linq.Expressions;


namespace Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly DataContext _context;
    public Repository(DataContext context)
    {
        _context = context;
    }

    private DbSet<T> Table { get => _context.Set<T>(); }
  
    public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();
    public async Task<T> GetByIdAsync(Guid id) => await Table.FindAsync(id);

    public IQueryable<T> GetAll(
          Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (disableTracking) query = query.AsNoTracking();
        if (include != null) query = include(query);
        if (predicate != null) query = query.Where(predicate);
        if (orderby != null) return orderby(query);
        else return query;

    }
    public T GetSingle(
       Expression<Func<T, bool>> predicate = null,
       Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
    {
        IQueryable<T> query = _context.Set<T>();
        if (disableTracking) query = query.AsNoTracking();
        if (include != null) query = include(query);
        if (predicate != null) query = query.Where(predicate);
        if (orderby != null) return orderby(query).FirstOrDefault();
        else return query.FirstOrDefault();

    }

    public async Task<T> AddAsync(T entity)
    {
        try
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity), "Entity degeri bos olamaz!");
            EntityEntry<T> addResult = await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addResult.Entity;
        }
        catch (DbUpdateException exception)
        {
            throw new Exception(exception.InnerException != null ? exception.InnerException.Message : exception.Message);
        }
    }

    public async Task<List<T>> AddRangeAsync(List<T> entities)
    {
        try
        {
            if (entities.Count == 0) throw new ArgumentNullException(nameof(entities), "Liste bos olamaz!");
            await Table.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
        catch (DbUpdateException exception)
        {
            throw new Exception(exception.InnerException != null ? exception.InnerException.Message : exception.Message);
        }
    }
    public async Task<bool> DeleteAllAsync()
    {
        try
        {
            if (Table.Any())
            {
                Table.RemoveRange(Table);
                await _context.SaveChangesAsync();
            }
            return true;
        }
        catch (DbUpdateException exception)
        {
            return false;
        }
    }
    public async Task<bool> DeleteAllAsync(List<T> entities)
    {
        try
        {
            if (entities.Count == 0) throw new ArgumentNullException(nameof(entities), "Liste bos olamaz!");
            Table.RemoveRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity), "Entity degeri bos olamaz!");
            Table.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteByIdAsync(Guid Id)
    {
        try
        {
            var deleteEntity = Table.FirstOrDefault(x => x.Id == Id);
            if (deleteEntity is null) throw new ArgumentNullException(nameof(deleteEntity), "Entity degeri bos olamaz!");
            Table.Remove(deleteEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<T> UpdateAsync(T entity)
    {
        try
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity), "Entity degeri bos olamaz!");
            EntityEntry<T> updateResult = Table.Update(entity);
            await _context.SaveChangesAsync();
            return updateResult.Entity;
        }
        catch (DbUpdateException exception)
        {
            throw new Exception(exception.InnerException != null ? exception.InnerException.Message : exception.Message);
        }
    }
    public async Task<bool> UpdateRangeAsync(List<T> entities)
    {
        try
        {
            if (entities is null) throw new ArgumentNullException(nameof(entities), "Liste bos olamaz!");
            Table.UpdateRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException exception)
        {
            throw new Exception(exception.InnerException != null ? exception.InnerException.Message : exception.Message);
        }
    }


    public async Task<T> UpdatePropertyAsync(T entity)
    {
        try
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity), "Entity degeri bos olamaz!");

            if (entity.Id == null) throw new ArgumentNullException(nameof(entity), "Entity degeri bos olamaz!");

            EntityEntry entry = this.Table.Entry(entity);
            if (entry != null)
            {
                entity.GetType().GetProperties().ToList()?.ForEach(p =>
                {
                    object value = p.GetValue(entity);
                    if (value != null && !value.Equals(null))
                    {
                        PropertyEntry entryProp = entry.Properties.Where(x => x.Metadata.GetColumnName() == p.Name).SingleOrDefault();
                        if (entryProp != null && !entryProp.Metadata.IsKey())
                        {
                            entryProp.CurrentValue = p.GetValue(entity);
                            entryProp.IsModified = true;

                        }
                    }
                });

                int sevStatus = await _context.SaveChangesAsync();
                this.Table.Entry(entity).State = EntityState.Detached; // takipten çıkarma

                if (sevStatus > 0)
                    return entity;
                else
                    return null;
            }

            return null;
        }
        catch (DbUpdateException exception)
        {
            throw new Exception(exception.InnerException != null ? exception.InnerException.Message : exception.Message);
        }
    }


}
