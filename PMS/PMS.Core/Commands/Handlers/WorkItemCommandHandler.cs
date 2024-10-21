using AutoMapper;
using MediatR;
using PMS.Core.Commands.Models;
using PMS.Shared.Contracts.Repositories;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Entities;
using PMS.Shared.Models.Results;

namespace PMS.Core.Commands.Handlers
{
    public sealed class WorkItemCommandHandler :
        IRequestHandler<CreateWorkItemCommand, Result<WorkItemDto>>
    {
        private readonly IWorkItemRepository _workItemRepository;
        private readonly IMapper _mapper;

        public WorkItemCommandHandler(IWorkItemRepository workItemRepository, IMapper mapper)
        {
            _workItemRepository = workItemRepository;
            _mapper = mapper;
        }

        public async Task<Result<WorkItemDto>> Handle(CreateWorkItemCommand request, CancellationToken cancellationToken)
        {
            // Convert command to entity before creating a work item
            var entity = _mapper.Map<WorkItem>(request);

            // Create a new work item in the database
            await _workItemRepository.CreateWorkItemAsync(entity, cancellationToken);

            // Convert entity to dto after creating a work item
            var dto = _mapper.Map<WorkItemDto>(entity);

            return Result<WorkItemDto>.Success(dto);
        }
    }
}
