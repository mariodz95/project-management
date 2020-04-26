using Common.Interface_Sort_Pag_Flt;

namespace Common.Sort_Pag_Flt
{
    public class Paging : IPaging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
