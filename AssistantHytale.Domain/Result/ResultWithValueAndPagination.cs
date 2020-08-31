using AssistantHytale.Domain.Contract;

namespace AssistantHytale.Domain.Result
{
    public class ResultWithValueAndPagination<T> : ResultWithValue<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }

        public ResultWithValueAndPagination(bool isSuccess, T value, int currentPage, int totalPages, int totalRows, string exceptionMessage) : base(isSuccess, value, exceptionMessage)
        {
            Value = value;
            IsSuccess = isSuccess;
            ExceptionMessage = exceptionMessage;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            TotalRows = totalRows;
        }

        public ResultWithValueAndPagination(bool isSuccess, T value, Pagination pagination, string exceptionMessage) : base(isSuccess, value, exceptionMessage)
        {
            Value = value;
            IsSuccess = isSuccess;
            ExceptionMessage = exceptionMessage;
            CurrentPage = pagination.CurrentPage;
            TotalPages = pagination.TotalPages;
            TotalRows = pagination.TotalRows;
        }

        public Pagination GetPagination()
        {
            return new Pagination
            {
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                TotalRows = TotalRows
            };
        }

        public override string ToString()
        {
            return $"Success: {IsSuccess}, Page: {CurrentPage}/{TotalPages}, ExceptionMessage: {ExceptionMessage}";
        }

        //public static ResultWithValueAndPagination<T> FromResult(ResultWithValue<T> oldResult, int currentPage, int totalPages, int totalRows)
        //{
        //    return new ResultWithValueAndPagination<T>(oldResult.IsSuccess, oldResult.Value, currentPage, totalPages, totalRows, oldResult.ExceptionMessage);
        //}

        //public static ResultWithValueAndPagination<T> FromResult(ResultWithValue<T> oldResult, Pagination pagination)
        //{
        //    return new ResultWithValueAndPagination<T>(oldResult.IsSuccess, oldResult.Value, pagination, oldResult.ExceptionMessage);
        //}
    }

    public static class PaginationResultHelper
    {
        public static ResultWithValueAndPagination<T> PaginationFromResult<T>(this Result oldResult, T value, Pagination pagination)
        {
            return new ResultWithValueAndPagination<T>(oldResult.IsSuccess, value, pagination, oldResult.ExceptionMessage);
        }

        public static ResultWithValueAndPagination<T> PaginationFromOld<T, TK>(this ResultWithValueAndPagination<TK> oldResult, T value)
        {
            return new ResultWithValueAndPagination<T>(oldResult.IsSuccess, value, oldResult.GetPagination(), oldResult.ExceptionMessage);
        }
    }
}
