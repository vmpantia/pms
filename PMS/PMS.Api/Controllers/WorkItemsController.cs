using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Core.Queries.Models;

namespace PMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkItemsController(IMediator mediator) => 
            _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetWorkItemsAsync()
        {
            var result = await _mediator.Send(new GetWorkItemsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkItemByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetWorkItemByIdQuery(id));
            return Ok(result);
        }
    }
}
