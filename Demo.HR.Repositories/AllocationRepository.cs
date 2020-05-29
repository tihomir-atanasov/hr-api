using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Demo.HR.Contracts.Repositories;
using Demo.HR.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace Demo.HR.Repositories
{
    public class AllocationRepository : BaseRepository, IAllocationRepository
    {
        public AllocationRepository(AppDbContext db)
            : base(db)
        {
        }

        public async Task<ICollection<UserAllocation>> GetAllocations(
            int currentPage,
            int pageSize,
            Expression<Func<UserAllocation, bool>> predicate,
            Expression<Func<UserAllocation, object>> sortCondition,
            bool sortDesc)
        {
            return await GetPaginatedAsync(
                currentPage,
                pageSize,
                predicate,
                sortCondition,
                sortDesc,
                include: s => s.Include(s => s.Project)
                               .Include(s => s.User)
                               .ThenInclude(u => u.UserProjects)
                               .ThenInclude(up => up.Project)
                               .Include(s => s.User)
                               .ThenInclude(u => u.UserRoles)
                               .ThenInclude(ur => ur.Role)
                               .Include(s => s.Role));
        }

        public async Task<int> GetAllocationsCount(Expression<Func<UserAllocation, bool>> predicate)
        {
            return await CountAsync(predicate);
        }
    }
}