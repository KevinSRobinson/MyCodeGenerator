using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly SamepleDbContext _context;
    private readonly DbSet<TEntity> _entities;

    protected Repository(SamepleDbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _entities.ToList();
    }

    public TEntity GetById(int id)
    {
        return _entities.Find(id);
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
    }
}
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Delete(T entity);
}
