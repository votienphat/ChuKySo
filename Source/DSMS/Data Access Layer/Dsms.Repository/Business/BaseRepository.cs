using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Dsms.Repository
{
    /// <summary>
    /// Base class for all SQL based service classes
    /// </summary>
    /// <typeparam name="T">The domain object type</typeparam>
    /// <history>
    /// - 2014/05/20: Created by Phat Vo
    /// </history>
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        internal DbSet<T> DbSet;
        internal DbContext Database { get { return _unitOfWork.Db; } }

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            DbSet = _unitOfWork.Db.Set<T>();
        }

        /// <summary>
        /// Returns the object with the primary key specifies or throws
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T Single(object primaryKey)
        {
            var dbResult = DbSet.Find(primaryKey);
            return dbResult;
        }

        /// <summary>
        /// Returns the object with the primary key specifies or the default for the type
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public T SingleOrDefault(object primaryKey)
        {
            var dbResult = DbSet.Find(primaryKey);
            return dbResult;
        }

        public bool Exists(object primaryKey)
        {
            return DbSet.Find(primaryKey) != null;
        }

        public virtual int Insert(T entity)
        {
            dynamic obj = DbSet.Add(entity);
            _unitOfWork.Db.SaveChanges();
            return obj.Id;

        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Db.SaveChanges();
        }

        public int Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dynamic obj = DbSet.Remove(entity);
            this._unitOfWork.Db.SaveChanges();
            return obj.Id;
        }

        public Dictionary<string, string> GetAuditNames(dynamic dynamicObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable().ToList();
        }

        #region Protected Methods

        public virtual IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<T> query = DbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => query = query.Include(i));

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;
        }

        #endregion
    }
}