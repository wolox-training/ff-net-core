using MvcMovie.Repositories.Database;
using MvcMovie.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataBaseContext _context;

        protected DataBaseContext Context { get { return this._context; } }

        public Repository(DataBaseContext context) => _context = context;

        public TEntity Get(int id) => _context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate);

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().SingleOrDefault(predicate);

        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);
    }
}
