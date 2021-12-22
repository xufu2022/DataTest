using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fu.Common.Data
{
    public interface IRepositoryBaseWrite<TEntity, in TKey> where TEntity : class, IEntity<TKey>
    {
        DbSet<TEntity> DbSet { get; }
        TEntity Insert(TEntity entity, bool autoSave = true);
        Task<bool> CanFindItemAsync(Expression<Func<TEntity, bool>> predicate);
        bool CanFindItem(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = true,
            CancellationToken cancellationToken = default);

        List<TEntity> GetList(bool includeDetails = false);

        Task<List<TEntity>> GetListAsync(bool includeDetails = false,
            CancellationToken cancellationToken = default);

        long GetCount();
        Task<long> GetCountAsync(CancellationToken cancellationToken = default);

        Task EnsureCollectionLoadedAsync<TProperty>(
            TEntity entity,
            Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression,
            CancellationToken cancellationToken = default)
            where TProperty : class;

        Task EnsurePropertyLoadedAsync<TProperty>(
            TEntity entity,
            Expression<Func<TEntity, TProperty>> propertyExpression,
            CancellationToken cancellationToken = default)
            where TProperty : class;

        IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[]? propertySelectors);

        /// <summary>
        /// Include split by using comma, can be used for nested references
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntity> WithDetails(string includeProperties = "");

        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>>? predicate);

        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[]? propertySelectors);

        TEntity Get(TKey id, bool includeDetails = true);

        Task<TEntity> GetAsync(TKey id, bool includeDetails = true,
            CancellationToken cancellationToken = default);

        TEntity? Find(TKey id, bool includeDetails = false);

        Task<TEntity?> FindAsync(TKey id, bool includeDetails = false,
            CancellationToken cancellationToken = default);

        void Delete(TKey id, bool autoSave = false);
        void Delete(TEntity entity, bool autoSave = true);

        void InsertOrUpdate(TEntity entity, TKey id, bool autoSave = false,
            CancellationToken cancellationToken = default);
    }

    public class RepositoryBaseWrite<TEntity, TKey> : IRepositoryBaseWrite<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly DbContext _context;

        public RepositoryBaseWrite(DbContext context)
        {
            _context = context;
        }

        public virtual DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public TEntity Insert(TEntity entity, bool autoSave = true)
        {
            var savedEntity = DbSet.Add(entity).Entity;
            if (autoSave)
            {
                _context.SaveChanges();
            }

            return savedEntity;
        }

        public async Task<bool> CanFindItemAsync(Expression<Func<TEntity, bool>> predicate) =>
            await DbSet.AnyAsync(predicate);

        public bool CanFindItem(Expression<Func<TEntity, bool>> predicate) => DbSet.Any(predicate);

        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = true,
            CancellationToken cancellationToken = default)
        {
            var savedEntity = DbSet.Add(entity).Entity;

            if (autoSave)
            {
                _ = await _context.SaveChangesAsync(cancellationToken);
            }

            return savedEntity;
        }


        public List<TEntity> GetList(bool includeDetails = false)
        {
            return includeDetails
                ? WithDetails().AsNoTracking().ToList()
                : DbSet.ToList();
        }


        public async Task<List<TEntity>> GetListAsync(bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().AsNoTracking().ToListAsync(cancellationToken)
                : await DbSet.ToListAsync(cancellationToken);
        }

        public long GetCount()
        {
            return DbSet.AsNoTracking().LongCount();
        }

        public async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().LongCountAsync(cancellationToken);
        }

        protected IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        public virtual async Task EnsureCollectionLoadedAsync<TProperty>(
            TEntity entity,
            Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression,
            CancellationToken cancellationToken = default)
            where TProperty : class
        {
            await _context
                .Entry(entity)
                .Collection(propertyExpression)
                .LoadAsync(cancellationToken);
        }


        public virtual async Task EnsurePropertyLoadedAsync<TProperty>(
            TEntity entity,
            Expression<Func<TEntity, TProperty>> propertyExpression,
            CancellationToken cancellationToken = default)
            where TProperty : class
        {
            await _context
                .Entry(entity)
                .Reference(propertyExpression!)
                .LoadAsync(cancellationToken);
        }


        public IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[]? propertySelectors)
        {
            var query = GetQueryable();

            if (propertySelectors == null) return query;
            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }

        /// <summary>
        /// Include split by using comma, can be used for nested references
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<TEntity> WithDetails(string includeProperties = "")
        {
            var query = GetQueryable();
            if (!string.IsNullOrWhiteSpace(includeProperties))
                query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>>? predicate)
        {
            var query = GetQueryable();
            if (predicate != null)
                return await query.Where(predicate).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[]? propertySelectors)
        {
            var query = WithDetails(propertySelectors);
            return await query.Where(predicate).ToListAsync();
        }

        protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

            Expression<Func<object>> closure = () => id!;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        public virtual TEntity Get(TKey id, bool includeDetails = true)
        {
            var entity = Find(id, includeDetails);

            if (entity == null)
            {
                throw new Exception();
            }

            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, includeDetails, cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            return entity;
        }

        public virtual TEntity? Find(TKey id, bool includeDetails = false)
        {
            return includeDetails
                ? WithDetails().FirstOrDefault(CreateEqualityExpressionForId(id))
                : DbSet.Find(id);
        }

        public virtual async Task<TEntity?> FindAsync(TKey id, bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().FirstOrDefaultAsync(CreateEqualityExpressionForId(id), cancellationToken)
                : await DbSet.FindAsync(new object[] {id!}, cancellationToken);
        }

        public virtual void Delete(TKey id, bool autoSave = false)
        {
            var entity = Find(id, includeDetails: false);
            if (entity != null)
                Delete(entity, autoSave);
        }

        public void Delete(TEntity entity, bool autoSave = true)
        {
            DbSet.Remove(entity);

            if (autoSave)
            {
                _context.SaveChanges();
            }
        }

        public virtual void InsertOrUpdate(TEntity entity, TKey id, bool autoSave = false,
            CancellationToken cancellationToken = default)
        {
            var existingItem = Find(id);
            if (existingItem != null)
                _context.Entry(existingItem).CurrentValues.SetValues(entity);
        }
    }

    public interface IRepositoryBaseRead<TEntity, in TKey> where TEntity : class, IEntity<TKey>
    {
        Task<bool> CanFindItemAsync(Expression<Func<TEntity, bool>> predicate);
        bool CanFindItem(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetList(bool includeDetails = false);

        Task<List<TEntity>> GetListAsync(bool includeDetails = false,
            CancellationToken cancellationToken = default);

        IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[]? propertySelectors);

        /// <summary>
        /// Include split by using comma, can be used for nested references
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntity> WithDetails(string includeProperties = "");

        TEntity Get(TKey id, bool includeDetails = true);

        Task<TEntity> GetAsync(TKey id, bool includeDetails = true,
            CancellationToken cancellationToken = default);

        TEntity? Find(TKey id, bool includeDetails = false);

        Task<TEntity?> FindAsync(TKey id, bool includeDetails = false,
            CancellationToken cancellationToken = default);
    }

    public class RepositoryBaseRead<TEntity, TKey> : IRepositoryBaseRead<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly DbContext _context;

        public RepositoryBaseRead(DbContext context)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
        }

        public virtual DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public async Task<bool> CanFindItemAsync(Expression<Func<TEntity, bool>> predicate) =>
            await DbSet.AnyAsync(predicate);

        public bool CanFindItem(Expression<Func<TEntity, bool>> predicate) => DbSet.Any(predicate);

        public List<TEntity> GetList(bool includeDetails = false)
        {
            return includeDetails
                ? WithDetails().AsNoTracking().ToList()
                : DbSet.ToList();
        }

        public async Task<List<TEntity>> GetListAsync(bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().AsNoTracking().ToListAsync(cancellationToken)
                : await DbSet.ToListAsync(cancellationToken);
        }

        public IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[]? propertySelectors)
        {
            var query = GetQueryable();

            if (propertySelectors == null) return query;
            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }
            return query;
        }

        /// <summary>
        /// Include split by using comma, can be used for nested references
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<TEntity> WithDetails(string includeProperties = "")
        {
            var query = GetQueryable();
            if (!string.IsNullOrWhiteSpace(includeProperties))
                query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }

        private IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        public virtual TEntity Get(TKey id, bool includeDetails = true)
        {
            var entity = Find(id, includeDetails);

            if (entity == null)
            {
                throw new Exception();
            }

            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, includeDetails, cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            return entity;
        }

        public virtual TEntity? Find(TKey id, bool includeDetails = false)
        {
            return includeDetails
                ? WithDetails().FirstOrDefault(CreateEqualityExpressionForId(id))
                : DbSet.Find(id);
        }

        public virtual async Task<TEntity?> FindAsync(TKey id, bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().FirstOrDefaultAsync(CreateEqualityExpressionForId(id), cancellationToken)
                : await DbSet.FindAsync(new object[] {id!}, cancellationToken);
        }

        protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

            Expression<Func<object>> closure = () => id!;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}