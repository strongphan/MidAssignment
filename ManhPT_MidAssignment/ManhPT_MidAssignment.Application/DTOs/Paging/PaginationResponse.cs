﻿namespace ManhPT_MidAssignment.Application.DTOs.Paging
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