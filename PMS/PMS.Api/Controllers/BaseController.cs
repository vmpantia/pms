using MediatR;
using Microsoft.AspNetCore.Mvc;
using PMS.Core.Queries.Models;
using PMS.Shared.Models.Enums;
using PMS.Shared.Models.Results;
using PMS.Shared.Models.Results.Errors;

namespace PMS.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator) =>
            _mediator = mediator;

        protected async virtual Task<IActionResult> HandleResultAsync<TData>(IRequest<Result<TData>> request) 
            where TData : class
        {
            try
            {
                var result = await _mediator.Send(request);

                if(result.IsSuccess) return Ok(result);

                return result.Error?.Type switch
                {
                    ErrorType.NotFound => NotFound(result),
                    _ => throw new NotImplementedException()
                };
            }
            catch (Exception ex)
            {
                return BadRequest(CommonError.Exception(ex));
            }
        }
    }
}
