namespace AssistantHytale.Domain.Result
{
    public class PaginationResultWithValue<T>: ResultWithValue<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public PaginationResultWithValue(bool isSuccess, T value, int currentPage, int totalPages, string exceptionMessage) : base(isSuccess, value, exceptionMessage)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }
    }
}
