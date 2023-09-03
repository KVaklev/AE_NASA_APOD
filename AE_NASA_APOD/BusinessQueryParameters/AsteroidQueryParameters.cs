namespace BusinessQueryParameters
{
    public class AsteroidQueryParameters
    {
        public string? Copyright { get; set; }

        public string? Title { get; set; }

        public DateTime? FromDateTime { get; set; }

        public DateTime? ToDateTime { get; set; }

        public string? SortBy { get; set; }

        public string? SortOrder { get; set; }

        //public int PageSize { get; set; } = 5;
        //public int PageNumber { get; set; } = 1;
    }
}