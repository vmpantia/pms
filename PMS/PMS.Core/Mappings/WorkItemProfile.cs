using AutoMapper;
using PMS.Shared.Models.Dtos;
using PMS.Shared.Models.Entities;

namespace PMS.Core.Mappings
{
    public class WorkItemProfile : Profile
    {
        public WorkItemProfile()
        {
            CreateMap<WorkItem, WorkItemDto>()
                .ForMember(dst => dst.LastModifiedAt, opt => opt.MapFrom(src => src.UpdatedAt ?? src.CreatedAt))
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.UpdatedBy ?? src.CreatedBy));
        }
    }
}
