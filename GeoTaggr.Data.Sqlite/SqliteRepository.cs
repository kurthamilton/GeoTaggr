using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GeoTaggr.Data.Sqlite
{
    public abstract class SqliteRepository
    {
        private readonly GeoTaggrContext _context;

        protected SqliteRepository(GeoTaggrContext context) 
        {
            _context = context;
        }        

        protected async Task<bool> AddOneAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        protected async Task<bool> DeleteOneAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        protected async Task<IReadOnlyCollection<T>> ReadManyAsync<T>(Expression<Func<T, bool>>? filter = null) where T : class
        {
            return await GetQuery(filter).ToArrayAsync();
        }

        protected Task<T?> ReadSingleAsync<T>(Expression<Func<T, bool>>? filter = null) where T : class
        {
            return GetQuery(filter).FirstOrDefaultAsync();
        }

        protected async Task<bool> UpdateOneAsync<T>(T entity) where T : class
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private IQueryable<T> GetQuery<T>(Expression<Func<T, bool>>? filter = null) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }
    }
}