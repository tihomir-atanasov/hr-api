using System.Net;
using System.Threading.Tasks;
using Demo.HR.Contracts.Services;
using Demo.HR.Models.Dtos;
using Demo.HR.Models.Dtos.Request;
using Demo.HR.Models.Dtos.Response;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Demo.HR.API.Controllers
{
    [AllowAnonymous]
    [Route("api/allocations")]
    [ApiController]
    public class AllocationController : ControllerBase
    {
        private readonly IAllocationService _allocationService;

        public AllocationController(IAllocationService allocationService)
        {
            _allocationService = allocationService;
        }

        /// <summary>
        /// Gets HR allocations
        /// </summary>
        /// <param name="filter">Composite filter</param>
        /// <returns>PagedResultDto</returns>
        // GET api/allocations
        [HttpGet("")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PagedResultDto<UserAllocationDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [OpenApiTag("allocations")]
        public async Task<ActionResult> Allocations([CustomizeValidator(RuleSet = "FilterDto")][FromQuery]AllocationsFilterDto filter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var items = await _allocationService.GetAllocations(filter);

            return Ok(items);
        }
    }
}
