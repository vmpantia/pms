using Microsoft.AspNetCore.Mvc;

namespace PMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        public WorkItemsController() { }

        public async Task<IActionResult> GetWorkItemsAsync()
        {
            return Ok();
        }
    }
}
