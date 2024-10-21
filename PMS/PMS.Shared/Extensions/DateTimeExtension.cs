namespace PMS.Shared.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTimeOffset GetCurrentDateTimeOffsetUtc() => DateTimeOffset.UtcNow;
    }
}
