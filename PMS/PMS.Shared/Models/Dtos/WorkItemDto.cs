﻿using PMS.Shared.Models.Enums;

namespace PMS.Shared.Models.Dtos
{
    public class WorkItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? AssigneeId { get; set; }
        public WorkItemType Type { get; set; }
        public WorkItemStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTimeOffset LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
