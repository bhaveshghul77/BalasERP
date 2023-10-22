namespace IBookedOnline.Domain
{
    public class Pagination
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? SortField { get; set; }
        public string? SortOrder { get; set; }
        public string? KeyWord { get; set; }
        public int Id { get; set; }
    }
}
