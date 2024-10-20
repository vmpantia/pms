using AutoMapper;
using MediatR;
using PMS.Core.Queries.Models;
using PMS.Shared.Contracts.Repositories;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Results;
using PMS.Shared.Models.Results.Errors;

namespace PMS.Core.Queries.Handlers
{
    public class WorkItemQueryHandler : 
        IRequestHandler<GetWorkItemsQuery, Result<IEnumerable<WorkItemDto>>>,
        IRequestHandler<GetWorkItemByIdQuery, Result<WorkItemDto>>
    {
        private readonly IWorkItemRepository _workItemRepository;
        private readonly IMapper _mapper;

        public WorkItemQueryHandler(IWorkItemRepository workItemRepository, IMapper mapper)
        {
            _workItemRepository = workItemRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<WorkItemDto>>> Handle(GetWorkItemsQuery request, CancellationToken cancellationToken)
        {
            var workItems = await _workItemRepository.GetWorkItemsAsync(cancellationToken: cancellationToken);
            var dto = _mapper.Map<IEnumerable<WorkItemDto>>(workItems);

            return Result<IEnumerable<WorkItemDto>>.Success(dto);
        }

        public async Task<Result<WorkItemDto>> Handle(GetWorkItemByIdQuery request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemRepository.GetWorkItemAsync(
                expression: data => data.Id.Equals(request.Id),
                cancellationToken: cancellationToken);

            if (workItem is null) 
                return Result<WorkItemDto>.Failure(WorkItemError.NotFound);

            var dto = _mapper.Map<WorkItemDto>(workItem);

            return Result<WorkItemDto>.Success(dto);
        }
    }
}
