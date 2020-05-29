using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Demo.HR.Models.Db;

namespace Demo.HR.Contracts.Repositories
{
    public interface IAllocationRepository
    {
        Task<ICollection<UserAllocation>> GetAllocations(int currentPage, int pageSize, Expression<Func<UserAllocation, bool>> predicate, Expression<Func<UserAllocation, object>> sortCondition, bool sortDesc);

        Task<int> GetAllocationsCount(Expression<Func<UserAllocation, bool>> predicate);
    }
}
