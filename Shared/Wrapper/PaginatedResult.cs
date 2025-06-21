using Shared.Interfaces;
using System;
using System.Collections.Generic;

namespace Shared.Wrapper
{
    public class PaginatedResult<T> : Result
    {
     

        public PaginatedResult(List<T> data)
        {
            Data = data;
        }

        public    List<T> Data { get; set; }

        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10,string sortBy="",string sortDirection="")
        {
            Data = data;
            PageNumber = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            SortBy=sortBy;
            SortDirection = sortDirection;
        }

        public static PaginatedResult<T> Failure(List<string> messages)
        {
            return new PaginatedResult<T>(false, default, messages);
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize, string sortBy = "", string sortDirection = "")
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize, sortBy,sortDirection);
        }
 
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public List<string> Messages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Succeeded { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}