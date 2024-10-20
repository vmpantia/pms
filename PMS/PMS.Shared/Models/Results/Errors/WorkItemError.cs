using PMS.Shared.Models.Entities;
using PMS.Shared.Models.Enums;

namespace PMS.Shared.Models.Results
{
    public class WorkItemError
    {
        public static readonly Error NotFound = new(ErrorType.NotFound, "Work Item not found in the database", nameof(WorkItem));
    }
}
