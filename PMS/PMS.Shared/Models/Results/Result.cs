namespace PMS.Shared.Models.Results
{
    public sealed class Result<TData> where TData : class
    {
        private Result(TData? data = null)
        {
            IsSuccess = true;
            Data = data;
        }

        private Result(Error error)
        {
            IsSuccess = false;
            Error = error;
        }

        public bool IsSuccess { get; set; }
        public TData? Data { get; set; }
        public Error? Error { get; set; }

        public static Result<TData> Success() => new();
        public static Result<TData> Success(TData data) => new(data);
        public static Result<TData> Failure(Error error) => new(error);
    }
}
