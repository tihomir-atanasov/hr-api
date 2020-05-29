using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Demo.HR.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Demo.HR.Repositories
{
    public abstract class BaseRepository
    {
        private readonly AppDbContext _db;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
        }

        protected AppDbContext Db => _db;

        protected virtual async Task<ICollection<T>> GetPaginatedAsync<T>(
            int currentPage,
            int pageSize,
            Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>> sortCondition,
            bool sortDesc,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            where T : Base
        {
            IQueryable<T> query = Db.Set<T>()
                .AsNoTracking()
                .Where(predicate);

            if (include != null)
            {
                query = include(query);
            }

            query = sortDesc ? query.OrderByDescending(sortCondition) : query.OrderBy(sortCondition);

            return await query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize).ToListAsync();
        }

        protected virtual async Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate)
            where T : Base
        {
            return await Db
                .Set<T>()
                .AsNoTracking()
                .Where(predicate)
                .CountAsync();
        }
    }
}
