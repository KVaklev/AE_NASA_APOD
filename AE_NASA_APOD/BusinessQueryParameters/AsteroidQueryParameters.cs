namespace BusinessQueryParameters
{
    public class AsteroidQueryParameters
    {
        public string? Name { get; set; }

        public double? EstimatedMaxDiameter { get; set; }

        public double? VelocityKmH { get; set; }

        public double Distance { get; set; }

        public string? SortBy { get; set; }

        public string? SortOrder { get; set; }

        public int PageSize { get; set; } = 3;
        public int PageNumber { get; set; } = 1;
    }
}