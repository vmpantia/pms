using AutoMapper;
using MediatR;
using PMS.Core.Queries.Models;
using PMS.Shared.Contracts.Repositories;
using PMS.Shared.Models.Dtos;

namespace PMS.Core.Queries.Handlers
{
    public class WorkItemQueryHandler : 
        IRequestHandler<GetWorkItemsQuery, IEnumerable<WorkItemDto>>,
        IRequestHandler<GetWorkItemByIdQuery, WorkItemDto>
    {
        private readonly IWorkItemRepository _workItemRepository;
        private readonly IMapper _mapper;

        public WorkItemQueryHandler(IWorkItemRepository workItemRepository, IMapper mapper)
        {
            _workItemRepository = workItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkItemDto>> Handle(GetWorkItemsQuery request, CancellationToken cancellationToken)
        {
            var workItems = await _workItemRepository.GetWorkItemsAsync(cancellationToken: cancellationToken);
            return _mapper.Map<IEnumerable<WorkItemDto>>(workItems);
        }

        public async Task<WorkItemDto> Handle(GetWorkItemByIdQuery request, CancellationToken cancellationToken)
        {
            var workItem = await _workItemRepository.GetWorkItemAsync(
                expression: data => data.Id.Equals(request.Id),
                cancellationToken: cancellationToken);

            if (workItem is null)
                throw new Exception($"Work item with an Id of {request.Id} is not found in the database.");

            return _mapper.Map<WorkItemDto>(workItem);
        }
    }
}
