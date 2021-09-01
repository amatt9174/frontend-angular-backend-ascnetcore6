using System.Collections.Generic;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pagIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PagIndex = pagIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PagIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}