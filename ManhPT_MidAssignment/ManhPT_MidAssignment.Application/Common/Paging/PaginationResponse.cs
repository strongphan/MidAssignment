namespace ManhPT_MidAssignment.Application.Common.Paging
{
    public class PaginationResponse<T>
    {
        public PaginationResponse(IEnumerable<T> data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }

        public IEnumerable<T> Data { get; }
        public int TotalCount { get; }
    }
}
