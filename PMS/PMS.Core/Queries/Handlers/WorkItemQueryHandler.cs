using AutoMapper;
using MediatR;
using PMS.Core.Queries.Models;
using PMS.Shared.Contracts.Repositories;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Results;

namespace PMS.Core.Queries.Handlers
{
    public sealed class WorkItemQueryHandler : 
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
            // Get work items from the database
            var workItems = await _workItemRepository.GetWorkItemsAsync(cancellationToken: cancellationToken);

            // Convert work items to dto after getting data from the database
            var dto = _mapper.Map<IEnumerable<WorkItemDto>>(workItems);

            return Result<IEnumerable<WorkItemDto>>.Success(dto);
        }

        public async Task<Result<WorkItemDto>> Handle(GetWorkItemByIdQuery request, CancellationToken cancellationToken)
        {
            // Get work item from the database
            var workItem = await _workItemRepository.GetWorkItemAsync(
                expression: data => data.Id.Equals(request.Id),
                cancellationToken: cancellationToken);

            // Check if the workItem is NULL
            if (workItem is null) 
                return Result<WorkItemDto>.Failure(WorkItemError.NotFound);

            // Convert work item to dto after getting data from the database
            var dto = _mapper.Map<WorkItemDto>(workItem);

            return Result<WorkItemDto>.Success(dto);
        }
    }
}
