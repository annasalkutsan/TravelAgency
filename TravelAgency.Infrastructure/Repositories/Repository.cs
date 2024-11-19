using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly TravelAgencyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(TravelAgencyDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }
    
    /// <summary>
    /// Получить запись по ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    /// <summary>
    /// Получить все записи
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    /// <summary>
    /// Поиск по условию
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    
    /// <summary>
    /// Добавить одну запись
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task AddAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    /// <summary>
    /// Добавить несколько записей
    /// </summary>
    /// <param name="entities"></param>
    /// <exception cref="ArgumentException"></exception>
    public async Task AddRangeAsync(ICollection<T> entities)
    {
        if (entities == null || entities.Count == 0)
            throw new ArgumentException("The collection of entities cannot be null or empty.", nameof(entities));

        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }
    
    /// <summary>
    /// Обновить запись
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    /// <summary>
    /// Удалить запись
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task RemoveAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}