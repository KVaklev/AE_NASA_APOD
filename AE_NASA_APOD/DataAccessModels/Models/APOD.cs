using System.ComponentModel.DataAnnotations;

namespace DataAccessModels.Models
{
    public class APOD
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Copyright { get; set; }
        public DateTime Date { get; set; }
        public string Explanation { get; set; }
        public string HdUrl { get; set; }
        public string Media_Type { get; set; }
        public string Service_Version { get; set; }

        [StringLength(1000, MinimumLength = 1, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
