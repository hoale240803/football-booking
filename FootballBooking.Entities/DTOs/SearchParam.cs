namespace FootballBooking.Entities.DTOs
{
    public class SearchParam
    {
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public string Keyword { get; set; }
    }
}