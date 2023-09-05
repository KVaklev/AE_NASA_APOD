using System.ComponentModel.DataAnnotations;

namespace BusinessDTOs
{
    public class GetAsteroidDTO
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Copyright { get; set; }

        [StringLength(10000, MinimumLength = 2, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Explanation { get; set; }
        public DateTime DateTime { get; set; }
        
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Title { get; set; }
        
    }
}