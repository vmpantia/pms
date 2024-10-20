using PMS.Shared.Models.Enums;

namespace PMS.Shared.Models.Results
{
    public sealed record Error(ErrorType Type, string Description, string? Resource = null, Exception? Exception = null) { }
}
