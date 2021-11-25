using BS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BS.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private BSContext _context = null;
        protected DbSet<TEntity> _dbSet;
        public BaseRepository(BSContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public BaseRepository()
        {
            _context = new BSContext();
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity GetById(object id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                    _context.Entry(entity).State = EntityState.Detached;

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEnumerable<TEntity> GetByAll()
        {

            try
            {
                return _dbSet.AsNoTracking().ToList<TEntity>();

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public TEntity Add(TEntity entity)
        {
            try
            {
                return _dbSet.Add(entity).Entity;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public TEntity Update(TEntity entityToUpdate)
        {
            try
            {
                _dbSet.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                return entityToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void RemoveById(object id)
        {
            try
            {
                TEntity entityToDelete = _dbSet.Find(id);
                Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Remove(TEntity entityToDelete)
        {
            try
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            try
            {
                _dbSet.RemoveRange(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
