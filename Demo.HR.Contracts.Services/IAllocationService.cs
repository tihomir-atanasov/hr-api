using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.HR.Models.Common.Enums;
using Demo.HR.Models.Dtos;
using Demo.HR.Models.Dtos.Request;
using Demo.HR.Models.Dtos.Response;

namespace Demo.HR.Contracts.Services
{
    public interface IAllocationService
    {
        Task<PagedResultDto<UserAllocationDto>> GetAllocations(AllocationsFilterDto filterDto);
    }
}
