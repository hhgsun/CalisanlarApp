namespace FinagotechCalisanlar.Data.App
{
    public class PaginationData<T>
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int PageNumber { get; set; }
        public List<T> Records { get; set; }

        public PaginationData(List<T> records, int total = 0, int limit = 10, int pageNumber = 0)
        {
            Records = records;
            Total = total;
            Limit = limit;
            PageNumber = pageNumber;
        }

    }
}
