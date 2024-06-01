﻿namespace ManhPT_MidAssignment.Application.Common.Paging
{
    public record FilterRequest
        (string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int PageSize);


}
