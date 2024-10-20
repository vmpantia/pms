using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Core.Queries.Models;

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
    }
}
