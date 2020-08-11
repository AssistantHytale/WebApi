namespace AssistantHytale.Domain.Result
{
    public class ResultWithValueAndPagination<T> : ResultWithValue<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public ResultWithValueAndPagination(bool isSuccess, T value, int totalPages, int currentPage, string exceptionMessage) : base(isSuccess, value, exceptionMessage)
        {
            Value = value;
            IsSuccess = isSuccess;
            ExceptionMessage = exceptionMessage;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }

        public override string ToString()
        {
            return $"Success: {IsSuccess}, Page: {CurrentPage}/{TotalPages}, ExceptionMessage: {ExceptionMessage}";
        }

        public static ResultWithValueAndPagination<T> FromResult(ResultWithValue<T> oldResult, int totalPages, int currentPage)
        {
            return new ResultWithValueAndPagination<T>(oldResult.IsSuccess, oldResult.Value, totalPages, currentPage, oldResult.ExceptionMessage);
        }
    }
}
