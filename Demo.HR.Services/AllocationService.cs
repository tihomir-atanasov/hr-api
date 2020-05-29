using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Demo.HR.Contracts.Repositories;
using Demo.HR.Contracts.Services;
using Demo.HR.Models.Common.Enums;
using Demo.HR.Models.Db;
using Demo.HR.Models.Dtos;
using Demo.HR.Models.Dtos.Request;
using Demo.HR.Models.Dtos.Response;

namespace Demo.HR.Services
{
    public class AllocationService : BaseService, IAllocationService
    {
        private readonly IAllocationRepository _allocationRepository;

        public AllocationService(
            IAllocationRepository allocationRepository,
            IMapper mapper)
            : base(mapper)
        {
            _allocationRepository = allocationRepository;
        }

        public async Task<PagedResultDto<UserAllocationDto>> GetAllocations(AllocationsFilterDto filterDto)
        {
            // Default filter is User Full Name asc
            Expression<Func<UserAllocation, object>> sortCondition = s => s.User.FullName;

            // Map filters
            Expression<Func<UserAllocation, bool>> predicate = s => 1 == 1;
            predicate = s => (!filterDto.ProjectId.HasValue || s.ProjectId == filterDto.ProjectId.Value)
                && (!filterDto.UserId.HasValue || s.UserId == filterDto.UserId.Value)
                && (!filterDto.RoleId.HasValue || s.RoleId == filterDto.RoleId.Value)
                && (!filterDto.StartDate.HasValue || s.StartDate == filterDto.StartDate.Value)
                && (!filterDto.EndDate.HasValue || s.EndDate == filterDto.EndDate.Value)
                && (!filterDto.FilterRule.HasValue
                        || (filterDto.FilterRule.Value == BusinessFilters.ActiveProjects && s.Project.IsActive)
                        || (filterDto.FilterRule.Value == BusinessFilters.NotActiveProjects && !s.Project.IsActive)
                        || (filterDto.FilterRule.Value == BusinessFilters.ActiveUsers && s.User.IsActive)
                        || (filterDto.FilterRule.Value == BusinessFilters.NotActiveUsers && !s.User.IsActive));

            // Map sort fields to DB fields
            switch (filterDto.Sort.ToLower())
            {
                case "employee":
                    sortCondition = s => s.User.FullName;
                    break;
                case "project":
                    sortCondition = s => s.Project.Name;
                    break;
                case "role":
                    sortCondition = s => s.Role.Name;
                    break;
            }

            // Default dir is Asc since default filter is User Full Name
            bool sortDesc = string.Equals(filterDto.SortDir, string.Empty, StringComparison.InvariantCultureIgnoreCase) || string.Equals(filterDto.SortDir, "asc", StringComparison.InvariantCultureIgnoreCase) ? false : true;

            return new PagedResultDto<UserAllocationDto>()
            {
                Page = filterDto.Page,
                Per = filterDto.Per,
                Data = Mapper.Map<ICollection<UserAllocationDto>>(await _allocationRepository.GetAllocations(filterDto.Page, filterDto.Per, predicate, sortCondition, sortDesc)),
                Total = await _allocationRepository.GetAllocationsCount(predicate)
            };
        }
    }
}
