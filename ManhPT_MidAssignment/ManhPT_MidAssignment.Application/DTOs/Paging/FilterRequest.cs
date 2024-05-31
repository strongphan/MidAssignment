namespace ManhPT_MidAssignment.Application.DTOs.Paging
{
    public record FilterRequest
        (string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int PageSize);


}
