using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Core.Commands.Models;
using PMS.Core.Queries.Models;
using PMS.Shared.Models.Dtos;

namespace PMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemsController : BaseController
    {
        public WorkItemsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetWorkItemsAsync() =>
            await HandleResultAsync(new GetWorkItemsQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkItemByIdAsync(Guid id) => 
            await HandleResultAsync(new GetWorkItemByIdQuery(id));

        [HttpPost]
        public async Task<IActionResult> CreateWorkItemAsync([FromBody] SaveWorkItemDto request) =>
            await HandleResultAsync(new CreateWorkItemCommand(request));
    }
}
